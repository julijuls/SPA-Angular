using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectSPA.AppConfigs;
using ProjectSPA.Interfaces;
using ProjectSPA.Models;
using ProjectSPA.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;

        }


        [HttpGet]
        [Route("{zip}")]
        public async Task<WeatherModel> GetWeather(int zip) => await _weatherService.GetWeather(zip);

        [HttpGet]
        [Route("history")]
        public async Task<IEnumerable<WeatherHistoryModel>> GetHistory() => await _weatherService.GetHistory();

    }
}
