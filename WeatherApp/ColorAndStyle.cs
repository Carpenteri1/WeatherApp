using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp
{
    public class ColorAndStyle
    {
        public static string SetTextColor(string color,string textInput)
        {
            switch (color.ToLower())
            {
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    return textInput;
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    return textInput;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    return textInput;
                case "magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    return textInput;
            }
            return textInput;
        }

        public static void SetTextColor(string color)
        {
            switch (color.ToLower())
            {
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    break; 
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
            }
        }


        public static void SetBackgroundColor(string input)
        {
            switch (input.ToLower())
            {
                case "green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case "white":
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                case "red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
            }
        }


        public static string SetTextPosition(string inputString,int x, int y)
        {
            Console.SetCursorPosition(x, y);
            return inputString;
        }
    }
}
