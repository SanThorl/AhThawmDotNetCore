using AHThawmDotNetCore.Shared;
using DotNetCore.mvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.mvcApp.Controllers
{
    public class BlogAdoDotNetController : Controller
    {
        private readonly AdoDotNetService _adoDotNetService;
        private readonly CommonService _commonService;

        public BlogAdoDotNetController(AdoDotNetService adoDotNetService, CommonService commonService)
        {
            _adoDotNetService = adoDotNetService;
            _commonService = commonService;
        }

        public IActionResult Index()
        {
            var result = _commonService.Add(1, 2);
            var lst = _adoDotNetService.Query<BlogModel>("select * from tbl_blog");
            return View(lst);
        }
    }
}
