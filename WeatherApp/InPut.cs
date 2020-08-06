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

        public static async Task<string> InPutString(int i)
       {
            string apiResponse = string.Empty;
            string input = string.Empty;

            if (i.Equals(1))
            {
                try
                {
                    input = EnterStringValue("Enter city name: ");
                    apiResponse = OutPut.PrintWeatherCondition(await data.GetAPIResponse(input, i));
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(ColorAndStyle.SetTextColor("red", e.Message));
                }
                finally
                {

                }
            }
            else if (i.Equals(2))
            {
                try
                {
                    int lon = int.Parse(EnterStringValue("Enter lat value: "));
                    int lat = int.Parse(EnterStringValue("Enter lon value: "));
                    Console.Clear();
                    apiResponse = OutPut.PrintWeatherCondition(await data.GetAPIResponse(lat, lon));
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }

            }
            else if (i.Equals(3))//TODO fix catch exception here
            {
                    foreach (var s in await AddCityNames(i))
                    {
                        apiResponse += "\n" + OutPut.PrintWeatherCondition(s) + "\n--------------";
                    }
            }
            else if (i.Equals(4))
            {
                try
                {
                    apiResponse = OutPut.PrintFourDaysForecast(await data.GetAPIResponse(EnterStringValue("Enter city name: "), i));
                }
                catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
               
            }
            else if (i.Equals(5))
            {
                try
                {
                    apiResponse = OutPut.PrintDailyForecast(await data.GetAPIResponse(EnterStringValue("Enter city name: "), i));
                }
                catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
            return apiResponse;
       }

        private static string EnterStringValue(string output)
        {
            Console.Write(output);
            string value = Console.ReadLine();
            if (value.Equals(string.Empty))
            {
                throw new Exception("Input cant be empty");
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
                    Console.Write("Type nothing and press enter to exit and continue\nEnter city name: ");
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
                    Console.Clear();
                    Console.WriteLine("Input cant be empty");
                    continueLoop = false;
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
