using AhThawmDotNetCore.ConsoleApp.BlogModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhThawmDotNetCore.ConsoleApp.HttpClientExamples
{
    internal class HttpClientExample2
    {
        public async Task Run()
        {
            await ReadJsonPlaceholderModel();
        }
        private async Task ReadJsonPlaceholderModel()
            {
                HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
                List<JsonPlaceholderModel> lst = JsonConvert.DeserializeObject<List<JsonPlaceholderModel>>(jsonStr)!;
                foreach (JsonPlaceholderModel item in lst)
                {
                    Console.WriteLine(item.title);
                    Console.WriteLine(item.body);
                    Console.WriteLine(item.id);
                    Console.WriteLine(item.userId);
                }
            }
            }
    }
}
