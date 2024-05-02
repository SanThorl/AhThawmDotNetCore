using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.mvcApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult DonutChart()
        {
            return View();
        }
    }
}
