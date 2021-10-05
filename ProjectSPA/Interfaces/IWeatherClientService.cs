using ProjectSPA.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSPA.Interfaces
{
    public interface IWeatherClientService
    {
        Task<WeatherInfo> GetWeatherInfo(int zip);

    }
}
