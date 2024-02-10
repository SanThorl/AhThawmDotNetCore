using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhThawmDotNetCore.ConsoleApp.AdoDotNetExmples
{
    public class AdoDotNetExample
    {
        #region Read
        public void Read()
        {
            Console.WriteLine("Read");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "gaj24@02";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            Console.WriteLine("Connection is Opening ...");
            connection.Open();
            Console.WriteLine("Connection is Opened.");

            string query = " select * from tbl_blog";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Console.WriteLine("Connection is Closing ...");
            connection.Close();
            Console.WriteLine("Connection is Closed.");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Title ..." + dr["BlogTitle"]);
                Console.WriteLine("Author..." + dr["BlogAuthor"]);
                Console.WriteLine("Content..." + dr["BlogContent"]);
            }
        }
        #endregion

        #region Edit
        public void Edit(int id)
        {
            Console.WriteLine("Edit");
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "gaj24@02";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            //Console.WriteLine("Connection is Opening ...");
            connection.Open();
           // Console.WriteLine("Connection is Opened.");

            string query = @"SELECT [BlogId]
                                    ,[BlogTitle]
                                    ,[BlogAuthor]
                                    ,[BlogContent]
                            FROM [dbo].[Tbl_Blog]
                            WHERE BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

           // Console.WriteLine("Connection is Closing ...");
            connection.Close();
            //Console.WriteLine("Connection is Closed.");

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine("Title ..." + dr["BlogTitle"]);
            Console.WriteLine("Author..." + dr["BlogAuthor"]);
            Console.WriteLine("Content..." + dr["BlogContent"]);
        }
        #endregion

        #region Create
        public void Create(string title, string author, string content)
        {
            Console.WriteLine("Create");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "gaj24@02";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

           // Console.WriteLine("Connection is Opening ...");
            connection.Open();
            //Console.WriteLine("Connection is Opened.");

            string query = @"INSERT INTO [dbo].[Tbl_Blog]([BlogTitle], [BlogAuthor], [BlogContent])
                            VALUES (@BlogTitle, @BlogAuthor, @BlogContent)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();

            //Console.WriteLine("Connection is Closing...");
            connection.Close();
           // Console.WriteLine("Connection is Closed.");

            string msg = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(msg);
        }
        #endregion

        #region Update
        public void Update(int id, string title, string author, string content)
        {
            Console.WriteLine("Update");
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "gaj24@02";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET     [BlogTitle]=@BlogTitle,
                                    [BlogAuthor]=@BlogAuthor,
                                    [BlogContent]=@BlogContent
                            WHERE   BlogId=@BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string msg = result > 0 ? "Updating Successful." : "Updating Failed.";

            Console.WriteLine(msg);
            #endregion
        }
            #region Delete
        public void Delete(int id)
        {
            Console.WriteLine("Delete");
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "gaj24@02";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"DELETE FROM[dbo].[Tbl_Blog]
                             WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string msg = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(msg);
        }
        #endregion

    }

}