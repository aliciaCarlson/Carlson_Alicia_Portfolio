using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    public class Person
    {
        // Class members with getters and setter with appropriate protection levels
        public string Name { get; private set; }
        public int GoldBalance { get; set; }
        public int Health { get; set; }

        // Class constructor
        public Person(string _name)
        {
            Name = _name;
            GoldBalance = 500;
            Health = 500;
        }

        public void DisplayStats()
        {
            // Output Stats for current instance of Person
            Console.WriteLine($"Adventurer Name - {this.Name}\n" +
                $"Health - {this.Health}\n" +
                $"Gold - {this.GoldBalance}");
        }

        public int ThrowHand()
        {
            // Output that RPS is going to be played
            Console.WriteLine("\nBattle with a game of Rock, Paper, Scissors");

            // Variable to hold hand value
            int handValue = 0;

            // bool and while loop to keep going until given vaild answer
            bool needVaildAnswer = true;
            while (needVaildAnswer)
            {
                // Display RPS Menu options
                Console.Write("What would you like to throw?\n" +
                    "1 - Rock\n" +
                    "2 - Paper\n" +
                    "3 - Scissors\n" +
                    "Enter the number or name of the hand you would like to throw: ");
                // Get user's response
                string handTrown = Validation.NotNullOrBlank(Console.ReadLine().ToLower(), "Enter the number or name of the hand you would like to throw: ");

                // Switch to handle user input accordingly
                switch (handTrown)
                {
                    // user plays rock
                    case "1":
                    case "rock":
                        {
                            // Assign handValue
                            handValue = 1;
                            // Stop loop
                            needVaildAnswer = false;
                            // Output to user
                            Console.WriteLine("You have thrown Rock.");
                        }
                        break;
                    // user plays paper
                    case "2":
                    case "paper":
                        {
                            // Assign handValue
                            handValue = 2;
                            // Stop loop
                            needVaildAnswer = false;
                            // Output to user
                            Console.WriteLine("You have thrown Paper.");
                        }
                        break;
                    // user plays scissors
                    case "3":
                    case "scissors":
                        {
                            // Assign handValue
                            handValue = 3;
                            // Stop loop
                            needVaildAnswer = false;
                            // Output to user
                            Console.WriteLine("You have thrown Scissors.");
                        }
                        break;
                    // user picks invalid answer
                    default:
                        {
                            // Let user know their choice was invaild
                            Console.WriteLine("Please enter only the number or the name of the hand you would like to throw.");
                            needVaildAnswer = true;
                        }
                        break;
                }
            }

            // return handValue to use with whichever method calls
            return handValue;
        }

    }
}
