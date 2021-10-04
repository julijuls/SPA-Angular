using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectSPA.AppConfigs;
using ProjectSPA.Interfaces;
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
        private readonly ITimeZoneService _timeZoneService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService, ITimeZoneService timeZoneService)
        {
            _logger = logger;
            _weatherService = weatherService;
            _timeZoneService = timeZoneService;
        }


        [HttpGet]
        [Route("{zip}")]
        public async Task<WeatherView> GetWeather(int zip)
        {

            var model = await _weatherService.GetWeather(zip);

            var timeZone = await _timeZoneService.GetTimeZone(model);

            //var timeZones = GetRegistryTimeZoneIds();
            var weatherView = new WeatherView
            {
                Temp = model.Main.Temp,
                CityName = model.Name,
                Timezone = timeZone,
                Icon=model.Weather.Select(x=>x.Icon).FirstOrDefault()

            };
            return weatherView;
        }


    }
}
