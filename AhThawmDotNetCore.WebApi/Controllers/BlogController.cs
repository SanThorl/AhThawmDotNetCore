using AhThawmDotNetCore.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhThawmDotNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BlogController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogModel> lst = _db.Blogs.OrderByDescending(x => x.BlogId).ToList();
            return Ok(lst);
        }

        [HttpGet ("{id}")]
        public IActionResult GetBlog(int id)
        {
            BlogModel item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if(item is null)
            {
                return NotFound("No Data Found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string msg = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(msg);
        }

        [HttpPut ("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            BlogModel item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if(item is null)
            {
                return NotFound("No Data Found.");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            int result = _db.SaveChanges();
            string msg = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(msg);
        }

        [HttpDelete ("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if(item is null)
            {
                return NotFound("No Data Found.");
            }
            _db.Blogs.Remove(item);

            int result = _db.SaveChanges();
            string msg = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(msg);
        }
    }
}
