using AHThawmDotNetCore.Shared;
using DotNetCore.mvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.mvcApp.Controllers
{
    public class BlogDapperController : Controller
    {
        private readonly DapperService _dapperService;

        public BlogDapperController(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public IActionResult Index()
        {
            var lst = _dapperService.Query<BlogModel>("select * from tbl_blog");
            return View(lst);
        }
    }
}
