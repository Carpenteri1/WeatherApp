using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WeatherApp
{
    public class ColorAndStyle
    {
        public static string SetTextColor(Colors color,string textInput)
        {
            switch (color.ToString().ToLower())
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

        public static void SetTextColor(Colors color)
        {
            switch (color.ToString().ToLower())
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


        public static void SetBackgroundColor(Colors color)
        {
            switch (color.ToString().ToLower())
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
                case "yellow":
                    Console.BackgroundColor = ConsoleColor.Yellow;
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
