// See https://aka.ms/new-console-template for more information
using AhThawmDotNetCore.ConsoleApp.AdoDotNetExmples;
using AhThawmDotNetCore.ConsoleApp.BlogModels;
using AhThawmDotNetCore.ConsoleApp.DapperExamples;
using AhThawmDotNetCore.ConsoleApp.EFCoreExamples;
using AhThawmDotNetCore.ConsoleApp.HttpClientExamples;
using AhThawmDotNetCore.ConsoleApp.RefitExample;
using AhThawmDotNetCore.ConsoleApp.RestClientExamples;
using Newtonsoft.Json;
using Serilog;
using System.Data;
using System.Data.SqlClient;

 Console.WriteLine("Hello, World!");

// F5 => Run
// Shift + F5 => Stop

// F9 => Preak Point

// Ctrl + K, C => Disable
// Ctrl + K, C => Enable

// Console.Read();

// Ctrl + .

#region Read
/*SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = ".";
sqlConnectionStringBuilder.InitialCatalog = "TestDb";
sqlConnectionStringBuilder.UserID = "sa";
sqlConnectionStringBuilder.Password = "gaj24@02";

string query = " select * from tbl_blog";

SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

Console.WriteLine("Connection is Opening ...");
connection.Open();
Console.WriteLine("Connection is Opened.");

SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);

Console.WriteLine("Connection is Closing ...");
connection.Close();
Console.WriteLine("Connection is Closed.");

foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["BlogId"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);
}
*/
#endregion

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();

//adoDotNetExample.Edit(27);
//adoDotNetExample.Edit(35);

//adoDotNetExample.Create("test title", "test author", "test content");

//adoDotNetExample.Update(33, "test title2", "test author2", "test content2");

//adoDotNetExample.Delete(31);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();

//dapperExample.Edit(29);

//dapperExample.Create("test dap title", "test dap author", "test dap content");

//dapperExample.Update(30, "test dap title2", "test dap author2", "test dap content2");

//dapperExample.Delete(26);

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Edit(24);

//eFCoreExample.Create("test EF title", "test EF author", "test EF content");

//eFCoreExample.Update(32, "test EF title2", "test EF author2", "test EF content2");

//eFCoreExample.Delete(27);

//Console.WriteLine("Waiting for API...");
//Console.ReadKey();

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

//RestClientExample restClientExample = new RestClientExample();
//restClientExample.Run();

//RefitExample refitExample = new RefitExample();
//refitExample.Run();
//BlogModel blog = new BlogModel();
//blog.BlogTitle = "Test 2";
//blog.BlogAuthor = "Test 3";
//blog.BlogContent = "Test 4";
//Console.WriteLine(blog);
//string json = JsonConvert.SerializeObject(blog);
//Console.WriteLine(json);
//Console.WriteLine(blog.BlogTitle);
//Console.WriteLine(blog.BlogAuthor);
//Console.WriteLine(blog.BlogContent);

//BlogModel blog2 = JsonConvert.DeserializeObject<BlogModel>(json)!;
//Console.WriteLine(blog2);
//Console.WriteLine(blog2.BlogTitle);
//Console.WriteLine(blog2.BlogAuthor);
//Console.WriteLine(blog2.BlogContent);
//HttpClientExample2 httpClientExample2 = new HttpClientExample2();
//httpClientExample2.Run();

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Generate(391);

//int pageSize = 10;
//AppDbContext db = new AppDbContext();
//int rowCount = db.Blogs.Count();

//int pageCount = rowCount / pageSize;
//Console.WriteLine($"Current Page Size : {pageCount}");

//if (rowCount % pageSize > 0)
//    pageCount++;
//Console.WriteLine($"Current Page Size : {pageCount}");

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/AhThawmDotNetCore.ConsoleApp.log", rollingInterval: RollingInterval.Hour)
    .CreateLogger();

Log.Information("Hello, world");

int a = 10, b = 0;
try
{
    Log.Debug("Dividing {A} by {B}", a, b);
    Console.WriteLine(a / b);
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong");
}
finally
{
    await Log.CloseAndFlushAsync();
}
Console.ReadKey();