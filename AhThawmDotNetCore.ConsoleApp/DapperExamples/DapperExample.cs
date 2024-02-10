using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhThawmDotNetCore.ConsoleApp.BlogModels;
using Dapper;
 
namespace AhThawmDotNetCore.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = "gaj24@02"
        };

        public void Read()
        {
            string query = @"SELECT [BlogId],[BlogTitle],[BlogAuthor],[BlogContent]
                            FROM [dbo].[Tbl_Blog]";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();

            foreach(BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Edit(int id)
        {
            string query = @"SELECT [BlogId], [BlogTitle], [BlogAuthor], [BlogContent]
                            FROM [dbo].[Tbl_Blog]
                            WHERE [BlogId] = @BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
            
            };
            

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            //var item = db.Query<BlogModel>(query, new { BlogId=id }).FirstOrDefault();
            var item = db.Query<BlogModel>(query, blog).FirstOrDefault();
            if(item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog] ([BlogTitle], [BlogAuthor], [BlogContent])
                            VALUES (@BlogTitle, @BlogAuthor, @BlogContent)";

            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, blog);

            string msg = result > 0 ? "Saving Successful." : "Saving Failed.";

            Console.WriteLine(msg);
        }

        public void Update(int id, string title, string author, string content)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle,
                                [BlogAuthor] = @BlogAuthor,
                                [BlogContent] = @BlogContent
                            WHERE BlogId= @BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, blog);

            string msg = result > 0 ? "Updating Successful." : "Updating Failed.";

            Console.WriteLine(msg);
        }
           
        public void Delete(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId=@BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string msg = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            Console.WriteLine(msg);
        }
    }
}
