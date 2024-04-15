using AhThawmDotNetCore.MinimalApi;
using AhThawmDotNetCore.MinimalApi.Models;
using AhThawmDotNetCore.MinmalApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System.Linq;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/AhThawmDotNetCore.MinimalApi.log", rollingInterval: RollingInterval.Hour)
    .CreateLogger();
try
{
    Log.Information("Starting web applicatoin");
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog(); // <-- Add this Line
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    //var summaries = new[]
    //{
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

    //app.MapGet("/weatherforecast", () =>
    //{
    //    var forecast = Enumerable.Range(1, 5).Select(index =>
    //        new WeatherForecast
    //        (
    //            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //            Random.Shared.Next(-20, 55),
    //            summaries[Random.Shared.Next(summaries.Length)]
    //        ))
    //        .ToArray();
    //    return forecast;
    //})
    //.WithName("GetWeatherForecast")
    //.WithOpenApi();

    app.MapGet("/api/blog", (AppDbContext _db) =>
    {
        List<BlogModel> lst = _db.Blogs.OrderByDescending(x => x.BlogId).ToList();

        Log.Information(JsonConvert.SerializeObject(lst, Formatting.Indented));

        return Results.Ok(lst);
    })
    .WithName("GetBlogs")
    .WithOpenApi();

    app.MapGet("/api/blog/{pageNo}/{pageSize}", (AppDbContext _db, int pageNo, int pageSize) =>
    {
        int rowCount = _db.Blogs.Count();

        int pageCount = rowCount / pageSize;
        if (rowCount % pageSize > 0)
            pageCount++;

        if (pageNo > pageCount)
        {
            return Results.BadRequest(new { Message = "Invalid PageNo." });
        }

        List<BlogModel> lst = _db.Blogs
            //.OrderByDescending(X => X.BlogId)
            .Skip((pageNo - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        BlogResponseModel model = new();
        model.Data = lst;
        model.PageSize = pageSize;
        model.PageNo = pageNo;
        model.PageCount = pageCount;

        //model.IsEndOfPage = pageNo == pageCount;

        return Results.Ok(model);
    })
        .WithName("GetBlogsByPagination")
        .WithOpenApi();

    app.MapPost("/api/blog", (AppDbContext _db, BlogModel blog) =>
    {
        _db.Blogs.Add(blog);
        int result = _db.SaveChanges();
        string message = result > 0 ? "Saving Successful." : "Saving Failed.";
        return Results.Ok(message);
    })
        .WithName("CreateBlog")
        .WithOpenApi();

    app.MapPut("/api/blog/{id}", (AppDbContext _db, int id, BlogModel blog) =>
    {
        BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
        if (item is null)
        {
            return Results.NotFound("No Data is Found.");
        }

        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;

        int result = _db.SaveChanges();

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        return Results.Ok(message);
    })
        .WithName("UpdateBlog")
        .WithOpenApi();

    app.MapDelete("/api/blog", (AppDbContext _db, int id) =>
    {
        BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
        if (item is null)
        {
            return Results.NotFound("No Data is Found.");
        }

        _db.Blogs.Remove(item);
        int result = _db.SaveChanges();

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        return Results.Ok(message);
    })
        .WithName("DeleteBlog")
        .WithOpenApi();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedlyy");
}
finally
{
    Log.CloseAndFlush();
}
//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
