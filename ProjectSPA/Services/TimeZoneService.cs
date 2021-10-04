using Microsoft.Extensions.Options;
using ProjectSPA.AppConfigs;
using ProjectSPA.Models;
using ProjectSPA.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace ProjectSPA.Services
{
    public class TimeZoneService : ITimeZoneService
    {
        private readonly TimeZoneConfig _timeZoneConfig;
        private readonly RestClient _timeZonerRestClient;

        private const string GOOGLE_TIMEZONE_REQUEST = "/timezone/json";

        public TimeZoneService(IOptions<TimeZoneConfig> openWeatherConfig)
        {
            _timeZoneConfig = openWeatherConfig?.Value ?? throw new ArgumentNullException(nameof(OpenWeatherConfig));
            _timeZonerRestClient = new RestClient(_timeZoneConfig.BaseUrl);
            _timeZonerRestClient.AddDefaultParameter("key", _timeZoneConfig.PrivateKey);
        }



        public async Task<string> GetTimeZone(WeatherInfo weather)
        {

            var request = new RestRequest(GOOGLE_TIMEZONE_REQUEST, Method.GET);

            var location = string.Join(',', weather.Coord.Lat.ToString(CultureInfo.InvariantCulture), weather.Coord.Lon.ToString(CultureInfo.InvariantCulture));
            request.AddParameter("location", location);
            request.AddParameter("timestamp", weather.Dt);
            request.AddParameter("sensor", "false");
            var response = await _timeZonerRestClient.ExecuteAsync<GoogleTimeZone>(request);
            return response.Data.TimeZoneName;
            // then outputs city name, current temperature and time zone.
        }


    }
}
