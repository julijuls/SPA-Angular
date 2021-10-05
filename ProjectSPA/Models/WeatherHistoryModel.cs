using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSPA.Models
{
    public class WeatherHistoryModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public double Temp { get; set; }
        public string Timezone { get; set; }
        public string Icon { get; set; }
        public DateTime DatetimeRequest { get; set; }
    }
}
