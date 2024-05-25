using DotNetCore.mvcApp.Models;
using DotNetCore.mvcApp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore.mvcApp;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    //    {
    //        DataSource = ".",
    //        InitialCatalog = "TestDb",
    //        UserID = "sa",
    //        Password = "gaj24@02",
    //        TrustServerCertificate = true
    //    };
    //    optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
    //}
    public DbSet<BlogModel> Blogs { get; set; }

    public DbSet<PageStatisticsModel> PageStatistics { get; set; }

    public DbSet<RadarModel> Radars { get; set; }

    public DbSet<CanvasBarModel> Bars { get; set; }

    public DbSet<JSChartModel> JSBar { get; set; }
}
