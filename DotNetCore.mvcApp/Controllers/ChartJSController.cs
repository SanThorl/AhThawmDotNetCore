using DotNetCore.mvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.mvcApp.Controllers
{
    public class ChartJSController : Controller
    {
        private readonly AppDbContext _db;

        public ChartJSController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult BarChart()
        {
            var lst = _db.JSBar.ToList();
            JSChartResponseModel model = new JSChartResponseModel();
            model.Labels = lst.Select(x => x.Month).ToList();
            model.Series = lst.Select(x => x.Points).ToList();
            return View(model);
        }
    }
}
