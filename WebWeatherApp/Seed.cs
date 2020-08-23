﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Data;
using WebWeatherApp.Models;

namespace WebWeatherApp
{
    public class Seed
    {
        public static async Task<WeatherData> PopulateWeatherModel()
        {
            FetchData fetch = new FetchData();
            WeatherData weatherData = await fetch.GetAPIResponse("Gothenburg",1);
            return weatherData;
        }
    }
}