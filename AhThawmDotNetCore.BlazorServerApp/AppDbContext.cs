using AhThawmDotNetCore.BlazorServerApp.Models;
using AhThawmDotNetCore.BlazorServerApp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhThawmDotNetCore.BlazorServerApp;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    DbSet<BlogModel> Blogs { get; set; }

}
