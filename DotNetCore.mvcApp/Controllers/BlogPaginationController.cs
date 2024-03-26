using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.mvcApp.Controllers
{
    public class BlogPaginationController : Controller
    {
        public IActionResult BlogIndex()
        {
            AppDbContext db = new AppDbContext(); 
            return View("BlogIndex");
        }
    }
}
