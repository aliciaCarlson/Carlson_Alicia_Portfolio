using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Carlson_Alicia_DatabaseReview
{
    public class Validation
    {
        public static float GetFloat(string input, string message = "Please enter a vaild number: ")
        {
            float validatedFloat;


            while (!float.TryParse(input, out validatedFloat))
            {
                Console.Write("Please enter a vaild number: ");
                input = Console.ReadLine();

            }

            return validatedFloat;

        }


        public static int GetInt(string input)
        {
            int validatedInt;


            while (!int.TryParse(input, out validatedInt))
            {
                Console.Write("Please enter a vaild number: ");
                input = Console.ReadLine();

            }

            return validatedInt;

        }

        public static int GetInt(int min, int max, string input)
        {
            int validatedInt;


            while (!int.TryParse(input, out validatedInt) || (validatedInt < min || validatedInt > max))
            {
                Console.Write("Please enter a vaild response: ");
                input = Console.ReadLine();

            }

            return validatedInt;

        }
        public static double GetDouble(string input)
        {
            double validatedDouble;


            while (!double.TryParse(input, out validatedDouble))
            {
                Console.Write("Please enter a vaild response: ");
                input = Console.ReadLine();

            }

            return validatedDouble;

        }

        public static decimal GetDecimal(string input)
        {
            decimal validatedDecimal;


            while (!decimal.TryParse(input, out validatedDecimal))
            {
                Console.Write("Please enter a vaild number: ");
                input = Console.ReadLine();

            }

            return validatedDecimal;
        }


            public static string NotNullOrBlank(string input, string message)
        {
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please do not leave blank.");
                Console.Write(message);
                input = Console.ReadLine();

            }

            return input;

        }

        public static string NotNullOrBlankYesOrNo(string input, string message)
        {
            while (string.IsNullOrWhiteSpace(input) && (input.ToLower() != "y" && input.ToLower() != "n"))
            {
                Console.WriteLine("Please do not leave blank and only enter y / n");
                Console.Write(message);
                input = Console.ReadLine();

            }

            return input;

        }

        public static string NotNullOrBlank3Vars(string input, string first, string second, string third, string message)
        {
            while (string.IsNullOrWhiteSpace(input) && (input != first && input != second && input != third))
            {
                Console.WriteLine($"Please do not leave blank and only enter {first} / {second} / {third}: ");
                Console.Write(message);
                input = Console.ReadLine();

            }

            return input;
        }

        public static void PauseBeforeContinuing(string message = "\n\nPress any key to return to Main Menu")
        {
            Console.Write($"\n\n{message}");
            Console.ReadKey();
        }


    }
}
