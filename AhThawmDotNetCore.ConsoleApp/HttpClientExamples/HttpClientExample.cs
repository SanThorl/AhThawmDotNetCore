using AhThawmDotNetCore.ConsoleApp.BlogModels;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AhThawmDotNetCore.ConsoleApp.HttpClientExamples
{
    internal class HttpClientExample
    {
        public async Task Run()
        {
            //await Read();
            //await Edit(39);
            //await Edit(0);
            //await Create("httpClient title", "httpClient author", "httpClient content");
            //await Update(40, "httpClient title2", "httpClient author2", "httpClient content2");
            await Delete(41);
        }
        private async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7079/api/Blog");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(json)!;
                foreach(BlogModel item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Edit(int id)
        {
            string url = $"https://localhost:7079/api/Blog/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(json)!;
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string jsonBlog = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);
            string url = $"https://localhost:7079/api/Blog";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Update(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string jsonBlog = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);
            string url = $"https://localhost:7079/api/Blog/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
        
        private async Task Delete(int id)
        {
            string url = $"https://localhost:7079/api/Blog/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
