using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSPA.Models
{
    public class WeatherInfo
    {
        public Coord Coord { get; set; } 
        public List<Weather> Weather { get; set; }
        public string Base { get; set; } 
        public Main Main { get; set; } 
        public int  Visability { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int TimeZone { get; set; }  
        public int Id { get; set; }  
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
