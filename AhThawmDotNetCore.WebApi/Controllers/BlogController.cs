using AhThawmDotNetCore.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace AhThawmDotNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly AppDbContext _db;
        public BlogController(ILogger<BlogController> logger)
        {
            _db = new AppDbContext();
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogModel> lst = _db.Blogs.OrderByDescending(x => x.BlogId).ToList();
            _logger.LogInformation("Count is" + lst.Count.ToString());
            _logger.LogInformation(JsonConvert.SerializeObject(lst, Formatting.Indented)); 
            return Ok(lst);
        }

        [HttpGet("{pageNo}/{pageSize}")]
        [HttpGet("pageNo/{pageNo}/pageSize/{pageSize}")]
        public IActionResult GetBlogs(int pageNo, int pageSize)
        {
            int rowCount = _db.Blogs.Count();

            int pageCount = rowCount / pageSize;
            if (rowCount % pageSize > 0)
                pageCount++;

            if(pageNo > pageCount)
            {
                return BadRequest(new { Message = "Invalid PageNo." });
            }

            List<BlogModel> lst = _db.Blogs
                //.OrderByDescending(X => X.BlogId)
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            BlogResponseModel model = new();
            model.Data = lst;
            model.PageSize = pageSize;
            model.PageNo = pageNo;
            model.PageCount = pageCount;

            //model.IsEndOfPage = pageNo == pageCount;

            return Ok(model);
        }

        [HttpGet ("{id}")]
        public IActionResult GetBlog(int id)
        {
            BlogModel item = _db.Blogs.FirstOrDefault(item => item.BlogId == id)!;
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
            BlogModel item = _db.Blogs.FirstOrDefault(item => item.BlogId == id)!;
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

        public IActionResult GenerateBlogList()
        {
            List<BlogModel> lstBlogModel = new();
            for (int i = 1; i <= 395; i++)
            {
                BlogModel item = new BlogModel
                {
                    BlogTitle = $"BlogTitle{i}",
                    BlogAuthor = $"BlogAuthor{i}",
                    BlogContent = $"BlogContent{i}"
                };
                lstBlogModel.Add(item);
            }

            _db.Blogs.AddRange(lstBlogModel);
            int result = _db.SaveChanges();
            string msg = result > 0 ? "Success." : "Failed.";
            return Ok(msg);
        }
    }
}
