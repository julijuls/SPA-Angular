﻿using ProjectSPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSPA.Interfaces
{
    public interface ITimeZoneService
    {
        Task<string> GetTimeZone(WeatherInfo weather);
    }
}
