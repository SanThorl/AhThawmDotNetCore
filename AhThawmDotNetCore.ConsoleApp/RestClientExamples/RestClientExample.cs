using AhThawmDotNetCore.ConsoleApp.BlogModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhThawmDotNetCore.ConsoleApp.RestClientExamples
{
    internal class RestClientExample
    {
        private readonly string _apiUrl = "https://localhost:7079/api/Blog";
        public async Task Run()
        {
            //await Read();
            //await Edit(40);
            //await Edit(0);
            // await Create("restClient title1", "restClient author1", "restClient content1");
            //await Create("restClient title2", "restClient author2", "restClient content2");
            //await Update(43, "rest title", "rest author", "rest content");
           // await Delete(42);
        }
        private async Task Read()
        {
            RestRequest request = new RestRequest(_apiUrl, Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content!;
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
                Console.WriteLine(response.Content!);
            }
        }

        public async Task Edit(int id)
        {
            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content!;
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(json)!;
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }

        public async Task Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle=title,
                BlogAuthor=author,
                BlogContent=content
            };

            RestRequest request = new RestRequest(_apiUrl, Method.Post);
            request.AddJsonBody(blog);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }

        public async Task Update(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle=title,
                BlogAuthor=author,
                BlogContent=content
            };
            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Put);
            request.AddJsonBody(blog);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }

        private async Task Delete(int id)
        {
            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Delete);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }
    }
}
