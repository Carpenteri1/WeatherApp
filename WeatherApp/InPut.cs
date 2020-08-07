using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Data;

namespace WeatherApp
{
    public class InPut
    {
        private static WeatherData weathers;
        private static FetchData data = new FetchData();
        private const int _SearchForOneCity = 1;
        private const int _SearchBylongLat = 2;
        private const int _SearchForMultipleCities = 3;
        private const int _FourDaysForeCast = 4;
        private const int _DailyForCast = 5;

        public static async Task<string> InPutString(int i)
       {
            string apiResponse = string.Empty;
            string input = string.Empty;

            if (i.Equals(_SearchForOneCity))
            {
                    input = EnterStringValue("Enter city name: ");
                    apiResponse = OutPut.PrintWeatherCondition(await data.GetAPIResponse(input, i));
            }
            else if (i.Equals(_SearchBylongLat))
            {
                    int lon = int.Parse(EnterStringValue("Enter lat value: "));
                    int lat = int.Parse(EnterStringValue("Enter lon value: "));
                    Console.Clear();
                    apiResponse = OutPut.PrintWeatherCondition(await data.GetAPIResponse(lat, lon));
            }
            else if (i.Equals(_SearchForMultipleCities))
            {
                    foreach (var s in await AddCityNames(i))
                    {
                        apiResponse += "\n" + OutPut.PrintWeatherCondition(s) + "\n--------------";
                    }
            }
            else if (i.Equals(_FourDaysForeCast))
            {
                    apiResponse = OutPut.PrintFourDaysForecast(await data.GetAPIResponse(EnterStringValue("Enter city name: "), i));
            }
            else if (i.Equals(_DailyForCast))
            {
                 apiResponse = OutPut.PrintDailyForecast(await data.GetAPIResponse(EnterStringValue("Enter city name: "), i));
            }

            return apiResponse;
       }

        private static string EnterStringValue(string output)
        {
            Console.Write(output);
            string value = string.Empty;
            value = Console.ReadLine();

            if (value.Equals(string.Empty))
            {
                throw new Exception("Input cant be empty!");
            }
            return value;
        }

        private static async Task<List<WeatherData>> AddCityNames(int value)
        {
            List<WeatherData> listOfWeatherData = new List<WeatherData>();
            Console.Clear();
            bool continueLoop = true;
            string input = string.Empty;

            while (continueLoop.Equals(true))
            {
                #region menu prompts
                if (listOfWeatherData.Count < 1)
                {
                    ColorAndStyle.SetTextColor(Colors.red);
                    Console.Write(ColorAndStyle.SetTextColor(Colors.red, "Type nothing and press enter to exit and continue"));
                    Console.WriteLine(ColorAndStyle.SetTextColor(Colors.white, "\nEnter city name: "));
                    input = Console.ReadLine();
                }
                else
                {
                    Console.Write("Enter another city name: ");
                    input = Console.ReadLine();
                }
                #endregion

                #region handle user input
                if (!input.Equals(string.Empty))
                {
                    weathers = await data.GetAPIResponse(input, 1);
                    listOfWeatherData.Add(weathers);
                }
                else if (listOfWeatherData.Count < 1 && input.Equals(string.Empty))
                {
                    throw new Exception("first input cant be empty!!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("----------------------------");
                    continueLoop = false;
                }
                #endregion
            }

            return listOfWeatherData;
        }


    }
}
