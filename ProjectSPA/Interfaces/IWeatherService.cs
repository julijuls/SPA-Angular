
using ProjectSPA.DAL.Models;
using ProjectSPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSPA.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetWeather(int zip);
        Task<IEnumerable<WeatherHistoryModel>> GetHistory();
    }
}
