using HomeWork.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace HomeWork.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PileController : ControllerBase
    {
        private readonly string _url = "https://burma-project-ideas.vercel.app/pick-a-pile";
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<PileQuestionModel> pile = JsonConvert.DeserializeObject<List<PileQuestionModel>>(json)!;
                return Ok(pile);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<PileAnswerModel> pile = JsonConvert.DeserializeObject<List<PileAnswerModel>>(json)!;
                return Ok(pile);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
