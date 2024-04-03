using AHThawmDotNetCore.Shared;
using DotNetCore.mvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.mvcApp.Controllers
{
    public class BlogAdoDotNetController : Controller
    {
        private readonly AdoDotNetService _adoDotNetService;

        public BlogAdoDotNetController(AdoDotNetService adoDotNetService)
        {
            _adoDotNetService = adoDotNetService;
        }

        public IActionResult Index()
        {
            var lst = _adoDotNetService.Query<BlogModel>("select * from tbl_blog");
            return View(lst);
        }
    }
}
