using Microsoft.Extensions.Options;
using ProjectSPA.AppConfigs;
using ProjectSPA.Interfaces;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace ProjectSPA.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly OpenWeatherConfig _openWeatherConfig;
        private readonly RestClient _weatherRestClient;

        public WeatherService(IOptions<OpenWeatherConfig> openWeatherConfig)
        {
            _openWeatherConfig = openWeatherConfig?.Value ?? throw new ArgumentNullException(nameof(OpenWeatherConfig));
            _weatherRestClient = new RestClient(_openWeatherConfig.BaseUrl);
            _weatherRestClient.AddDefaultHeader("x-rapidapi-key", _openWeatherConfig.PrivateKey);
        }

        public async Task<IRestResponse<WeatherView>> GetWeather(int zip)
        {
            
            var request = new RestRequest(Method.GET);
            request.AddParameter("ZIP", zip, ParameterType.GetOrPost);
            var response = await _weatherRestClient.ExecuteAsync<WeatherView>(request);
            return response;
            // then outputs city name, current temperature and time zone.
        }
        //public async Task<IRestResponse<WeatherView>> GetWeather2(RestClient client)
        //{
        //    var client2 = new RestClient("https://community-open-weather-map.p.rapidapi.com/weather?q=London%2Cuk&lat=0&lon=0&callback=test&id=2172797&lang=null&units=imperial&mode=xml");
        //    var request = new RestRequest(Method.GET);
        //    request.AddHeader("x-rapidapi-host", "community-open-weather-map.p.rapidapi.com");
        //    request.AddHeader("x-rapidapi-key", "76bbbac9cbmshd9c1ff3bdf68b55p1a5e37jsne10406728e34");
        //    IRestResponse response = await client.ExecuteAsync<WeatherView>(request);
        //    return (IRestResponse<WeatherView>)response;
        //}

    }
}
