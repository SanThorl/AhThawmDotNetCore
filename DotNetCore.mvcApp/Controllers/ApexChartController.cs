using DotNetCore.mvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore.mvcApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            ApexChartPieChartResponseModel model = new ApexChartPieChartResponseModel()
            {
                Series = new List<int> { 44, 55, 13, 43, 22 },
                Labels = new List<string> {"Team A", "Team B", "Team C", "Team D", "Team E" }
            };
            return View(model);
        }

        public IActionResult DashedLineChart() 
        {
            AppDbContext db = new AppDbContext();
            var lst = db.PageStatistics.ToList();
            ApexChartDashedLineResponseModel model = new ApexChartDashedLineResponseModel();
            List<ApexChartDashedLineModel> lstSeries = new List<ApexChartDashedLineModel>();

            var lstSessionDuration = lst.Select(X => X.SessionDuration).ToList();
            var lstPageViews = lst.Select(X => X.PageViews).ToList();
            var lstTotalVisits = lst.Select(X => X.TotalVisits).ToList();
            var lstDate = lst.Select(X => X.CreatedDate).ToList();

            lstSeries.Add(new ApexChartDashedLineModel { name = "Session Duration", data = lstSessionDuration });
            lstSeries.Add(new ApexChartDashedLineModel { name = "Page Views", data = lstPageViews });
            lstSeries.Add(new ApexChartDashedLineModel { name = "TotalVisits", data = lstTotalVisits });

            model.Series = lstSeries;
            model.Labels = lstDate;
            return View(model);
        }

        public IActionResult RadarChart()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.Radars.ToList();

            ApexChartRadarResponseModel model = new ApexChartRadarResponseModel();
            model.Series = lst.Select(X => X.Series).ToList();
            model.Labels = lst.Select(X => X.Month).ToList();

            return View(model  );
        }
    }
}
