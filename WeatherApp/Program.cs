using System;
using System.Threading.Tasks;
namespace WeatherApp
{
    class Program
    {   
        static async Task Main(string[] args)
        {
            Console.Title = "WeatherApp";
            await Menu.RunProgram();
        }

    }
}
