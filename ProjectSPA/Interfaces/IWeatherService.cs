using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSPA.Interfaces
{
    public interface IWeatherService
    {
       
        Task<IRestResponse<WeatherView>> GetWeather(int zip);

    }
}
