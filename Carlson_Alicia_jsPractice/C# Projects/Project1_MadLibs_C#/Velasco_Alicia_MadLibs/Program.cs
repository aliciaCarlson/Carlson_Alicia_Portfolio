using System;

namespace Velasco_Alicia_MadLibs
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Alicia Velasco
             * SDI 1910 Section 01
             * Mad Libs Assignment
             * 10 / 5 / 19
             * Refactored: 05 / 15 / 2020
             */

            // Ask the user for their name
            Console.WriteLine("Welcome to my Mad Libs.\n\nPlease enter your name to begin!");

            // Creating a variable to hold user's name with validation
            string userName = Validation.NotNullOrBlank(Console.ReadLine(), "Please enter you name to begin!");

            // Giving the user instructions for the questions to follow
            Console.WriteLine("\nHello, " + userName + "!\n\nPlease answer the following questions with the first word that comes to mind. Press enter or return to go to the next question.\n");

            // Asking the user to provide an animal
            Console.Write("Enter an animal: ");
            // Storing user's animal choice in variable with validation
            string animal = Validation.NotNullOrBlank(Console.ReadLine(), "Enter an animal: ");

            // Asking the user to provide a name
            Console.Write("Enter a name: ");
            // Storing user's name choice in variable with validation
            string name = Validation.NotNullOrBlank(Console.ReadLine(), "Enter a name: ");

            // Asking the user to provide an adjective
            Console.Write("Enter an adjective: ");
            // Storing user's adjective choice in variable with validation
            string adjective = Validation.NotNullOrBlank(Console.ReadLine(), "Enter an adjective");

            // Asking the user to provide a food item
            Console.Write("Enter something that you'd eat: ");
            // Storing user's food choice in variable with validation
            string food = Validation.NotNullOrBlank(Console.ReadLine(), "Enter something that you'd eat: ");

            // Asking the user to provide a year
            Console.Write("Enter a year: ");
            // Converting user year to double with validation
            double year = Validation.GetDouble(Console.ReadLine());

            // Asking the user to provide a cost
            Console.Write("Enter a cost: ");
            // Converting user cost to decimal with validation
            decimal cost = Validation.GetDecimal(Console.ReadLine());

            //Asking the use to provide a number
            Console.Write("Lastly, enter a number: ");
            // Converting user number to double with validation
            double number = Validation.GetDouble(Console.ReadLine());


            // Outputting the Mad Libs story with user responses
            Console.WriteLine($"\n\nLong ago, in the year {year}, there lived a(n) {animal} named {name}.\n" +
                $"{name} the {animal} was unhappy because he was {adjective}.\n" +
                $"In {year} it was frowned upon to be {adjective}.\n" +
                $"One day, {name} met a wizard.\n" +
                $"The wizard told {name} that he could buy {number} magical {food}(s) for ${cost}.\n" +
                $"to help him not be {adjective}! This offer was too good to pass up!\n" +
                $"{name} the {animal} bought the {food}(s) and ate them.\n" +
                $"Instantly, he was no longer {adjective} and lived happily ever after!");



        }
    }
}
