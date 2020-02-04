using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMemoryCache _memoryCache;

        public CountriesController(IHttpClientFactory clientFactory, IMemoryCache memoryCache)
        {
            _clientFactory = clientFactory;
            _memoryCache = memoryCache;
        }
        // GET: api/Countries
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationModel model)
        {
            var result = await _memoryCache.GetOrCreateAsync("Countries", async x =>
            {
                x.SlidingExpiration = TimeSpan.FromHours(1);

                var httpClient = _clientFactory.CreateClient();
                var response = await httpClient.GetAsync("https://restcountries.eu/rest/v2/all");

                if (response.IsSuccessStatusCode)
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Country>>(resultString);
                }
                return new List<Country>();
            });

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var total = result.Count;
            result = result.Skip(model.PageSize * model.Page).Take(model.PageSize).ToList();

            return Ok(new { data = result, total });
        }
        // GET: api/Countries/vn
        [HttpGet("{alpha2Code}", Name = "Get")]
        public async Task<IActionResult> Details([FromRoute] string alpha2Code)
        {
            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.GetAsync($"https://restcountries.eu/rest/v2/alpha/{alpha2Code}");

            if (response.IsSuccessStatusCode)
            {
                var resultString = await response.Content.ReadAsStringAsync();
                //return Ok(JsonConvert.DeserializeObject<CountryDetail>(resultString));
                return Ok(resultString);
            }
            return Ok(new CountryDetail());
        }
        
        // POST: api/Countries
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
