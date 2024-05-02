using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.mvcApp.Controllers
{
    public class ChartJSController : Controller
    {
        public IActionResult BarChart()
        {
            return View();
        }
    }
}
