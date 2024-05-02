using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.mvcApp.Controllers
{
    public class CanvasChartController : Controller
    {
        public IActionResult BarChart()
        {
            return View();
        }
    }
}
