using DotNetCore.mvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.mvcApp.Controllers
{
    public class BlogPaginationController : Controller
    {
        private readonly AppDbContext _db;

        public BlogPaginationController(AppDbContext db)
        {
            _db = db;
        }

        [ActionName("Index")]
        public IActionResult BlogIndex(int pageNo=1, int pageSize = 10)
        {

            int rowCount = _db.Blogs.Count();

            int pageCount = rowCount / pageSize;
            if (rowCount % pageSize > 0)
                pageCount++;
            
            if(pageNo > rowCount)
            {
                return Redirect("/Blog");
            }

            List<BlogModel> lst = _db.Blogs
                //.OrderByDescending(X => X.BlogId)
                .Skip((pageNo -1) * pageSize)
                .Take(pageSize)
                .ToList();

            BlogResponseModel model = new();
            model.Data = lst;
            model.PageSize = pageSize;
            model.PageNo = pageNo;
            model.PageCount = pageCount;

            return View("BlogIndex", model);
        }
    }
}
