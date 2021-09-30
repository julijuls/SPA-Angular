using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectSPA.AppConfigs;
using ProjectSPA.Interfaces;
using ProjectSPA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            //var client = new RestClient("https://community-open-weather-map.p.rapidapi.com/weather?q=London%2Cuk&lat=0&lon=0&callback=test&id=2172797&lang=null&units=imperial&mode=xml");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("x-rapidapi-host", "community-open-weather-map.p.rapidapi.com");
            //request.AddHeader("x-rapidapi-key", "76bbbac9cbmshd9c1ff3bdf68b55p1a5e37jsne10406728e34");
            //IRestResponse response = client.Execute(request);
        }
   
        [HttpGet("{zip}", Name = "GetRanking")]
        public async Task<IActionResult> GetByIdAsync(int zip) { 
        var model = await _weatherService.GetWeather(zip);
        return Ok(model);
    }


}
}
