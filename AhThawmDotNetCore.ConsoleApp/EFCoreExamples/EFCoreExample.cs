using AhThawmDotNetCore.ConsoleApp.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhThawmDotNetCore.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs.ToList();
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
            AppDbContext db = new AppDbContext();
            //BlogModel item = db.Blogs.Where(item => item.BlogId == id).FirstOrDefault();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id);
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
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();
            string msg = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(msg);
        }

        public void Update(int id, string title, string author, string content)
        {
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if(item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = db.SaveChanges();
            string msg = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(msg);
        }

        public void Delete(int id)
        {
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id)!;
            if (item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();
            string msg = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(msg);
        }

        public void Generate(int count)
        {
            for(int i=0; i< count; i++)
            {
                int rowNo = i + 1;
                Create("Title" + rowNo, "Author" + rowNo, "Content" + rowNo);
            }
        }
    }
}
