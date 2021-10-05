using Microsoft.Extensions.Options;
using ProjectSPA.AppConfigs;
using ProjectSPA.Interfaces;
using ProjectSPA.Models;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace ProjectSPA.Services
{
    public class WeatherClientService : IWeatherClientService
    {
        private readonly OpenWeatherConfig _openWeatherConfig;
        private readonly RestClient _weatherRestClient;

        public WeatherClientService(IOptions<OpenWeatherConfig> openWeatherConfig)
        {
            _openWeatherConfig = openWeatherConfig?.Value ?? throw new ArgumentNullException(nameof(OpenWeatherConfig));
            _weatherRestClient = new RestClient(_openWeatherConfig.BaseUrl);
            _weatherRestClient.AddDefaultHeader("x-rapidapi-key", _openWeatherConfig.PrivateKey);
        }

        public async Task<WeatherInfo> GetWeatherInfo(int zip)
        {
            
            var request = new RestRequest(Method.GET);
            request.AddParameter("zip", zip, ParameterType.GetOrPost);
            var response = await _weatherRestClient.ExecuteAsync<WeatherInfo>(request);
            return response.Data;
            // then outputs city name, current temperature and time zone.
        }


    }
}
