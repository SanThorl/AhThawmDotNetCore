using DotNetCore.mvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.mvcApp.Controllers
{
    public class CanvasChartController : Controller
    {
        private readonly AppDbContext _db;

		public CanvasChartController(AppDbContext db)
		{
			_db = db;
		}

		public IActionResult BarChart()
        {
			List<CanvasBarResponseModel> lst= _db.Bars.Select(x=> new CanvasBarResponseModel
			{
				label=x.Country,
				y= x.GTBRate,
			}).ToList();

			return View(lst);
        }
    }
}
