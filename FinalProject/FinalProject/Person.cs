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
        public string Name { get; private set; }
        public int GoldBalance { get; set; }
        public int Health { get; set; }

        public Person(string _name)
        {
            Name = _name;
            GoldBalance = 500;
            Health = 500;
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Adventurer Name - {this.Name}\n" +
                $"Health - {this.Health}\n" +
                $"Gold - {this.GoldBalance}");
        }

        public int ThrowHand()
        {
            Console.WriteLine("\nBattle with a game of Rock, Paper, Scissors");

            bool needVaildAnswer = true;
            int handValue = 0;

            while (needVaildAnswer)
            {
                Console.Write("What would you like to throw?\n" +
                    "1 - Rock\n" +
                    "2 - Paper\n" +
                    "3 - Scissors\n" +
                    "Enter the number or name of the hand you would like to throw: ");
                string handTrown = Validation.NotNullOrBlank(Console.ReadLine().ToLower(), "Enter the number or name of the hand you would like to throw: ");

                switch (handTrown)
                {
                    case "1":
                    case "rock":
                        {
                            handValue = 1;
                            needVaildAnswer = false;
                            Console.WriteLine("You have thrown Rock.");
                        }
                        break;
                    case "2":
                    case "paper":
                        {
                            handValue = 2;
                            needVaildAnswer = false;
                            Console.WriteLine("You have thrown Paper.");
                        }
                        break;
                    case "3":
                    case "scissors":
                        {
                            handValue = 3;
                            needVaildAnswer = false;
                            Console.WriteLine("You have thrown Scissors.");
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please enter only the number or the name of the hand you would like to throw.");
                            needVaildAnswer = true;
                        }
                        break;
                }
            }

            return handValue;
        }

    }
}
