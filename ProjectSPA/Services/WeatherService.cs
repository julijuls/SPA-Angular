using Microsoft.EntityFrameworkCore;
using ProjectSPA.DAL;
using ProjectSPA.DAL.Models;
using ProjectSPA.Interfaces;
using ProjectSPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSPA.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherClientService _weatherClientService;
        private readonly IGoogleClientService _googleClientService;
        private readonly ApplicationContext _db;
        public WeatherService(ApplicationContext db, IWeatherClientService weatherClientService, IGoogleClientService googleClientService)
        {
            _weatherClientService = weatherClientService;
            _googleClientService = googleClientService;
            _db = db;
        }
        public async Task<WeatherModel> GetWeather(int zip)
        {

            var model = await _weatherClientService.GetWeatherInfo(zip);
            var timeZone = await _googleClientService.GetTimeZone(model);
            var weatherView = new WeatherModel
            {
                Temp = model.Main.Temp,
                CityName = model.Name,
                Timezone = timeZone,
                Icon = model.Weather.Select(x => x.Icon).FirstOrDefault()

            };

            DateTime utcDate = DateTime.UtcNow;
            var weatherHistory = new WeatherHistory
            {
                Temp = model.Main.Temp,
                CityName = model.Name,
                Timezone = timeZone,
                Icon = model.Weather.Select(x => x.Icon).FirstOrDefault(),
                DatetimeRequest = utcDate
            };
            _db.WeatherHistory.Add(weatherHistory);
            await _db.SaveChangesAsync();
            return weatherView;
        }
        public async Task<IEnumerable<WeatherHistoryModel>> GetHistory()
            => await _db.WeatherHistory
                .Select(item => new WeatherHistoryModel
                {
                    DatetimeRequest = item.DatetimeRequest,
                    Id = item.Id,
                    CityName = item.CityName,
                    Temp = item.Temp,
                    Timezone = item.Timezone,
                    Icon = item.Icon

                }).OrderByDescending(item=>item.DatetimeRequest).ToListAsync();

    }
}
