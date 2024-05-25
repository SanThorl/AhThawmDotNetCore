using AhThawmDotNetCore.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhThawmDotNetCore.WebApi
{
    public class AppDbContext : DbContext
    {
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
        //       // Password = "gaj24@02",
        //        Password = "sasa@123",
        //        TrustServerCertificate = true
        //    };
        //    optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        //}


        public DbSet<BlogModel> Blogs { get; set; }
    }
}
