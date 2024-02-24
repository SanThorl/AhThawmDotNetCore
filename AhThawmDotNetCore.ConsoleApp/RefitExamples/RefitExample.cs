using AhThawmDotNetCore.ConsoleApp.BlogModels;
using AhThawmDotNetCore.ConsoleApp.RefitExamples;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace AhThawmDotNetCore.ConsoleApp.RefitExample
{
    internal class RefitExample
    {
        private readonly IBlogApi refitApi = RestService.For<IBlogApi>("https://localhost:7079");

        public async Task Run()
        {
            //await Read();
            //await Edit(24);
            //await Edit(0);
            //await Create("refit title", "refit author", "refit content");
            //await Create("refit title2", "refit author2", "refit content2");
            //await Update(45, "refit title2", "refit author3", "refit content4");
            await Delete(44);
        }

        private async Task Read()
        {
            var lst = await refitApi.GetBlogs();
            foreach(BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        private async Task Edit(int id)
        {
            try
            {
                var item = await refitApi.GetBlog(id);
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            catch(Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task Create(string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };
                string msg = await refitApi.CreateBlog(blog);
                Console.WriteLine(msg);
            }
            catch(Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task Update(int id, string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };
                string msg = await refitApi.UpdateBlog(id, blog);
                Console.WriteLine(msg);
            }
            catch(Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Delete(int id)
        {
            try
            {
                string msg = await refitApi.DeleteBlog(id);
                Console.WriteLine(msg);
            }
            catch(Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
