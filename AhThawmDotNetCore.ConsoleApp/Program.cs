// See https://aka.ms/new-console-template for more information
using AhThawmDotNetCore.ConsoleApp.AdoDotNetExmples;
using AhThawmDotNetCore.ConsoleApp.DapperExamples;
using AhThawmDotNetCore.ConsoleApp.EFCoreExamples;
using AhThawmDotNetCore.ConsoleApp.HttpClientExamples;
using AhThawmDotNetCore.ConsoleApp.RestClientExamples;
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

Console.WriteLine("Waiting for API...");
Console.ReadKey();

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

RestClientExample restClientExample = new RestClientExample();
restClientExample.Run();

Console.ReadKey();