using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    class Program
    {
        Person adventurer = null;

        static void Main(string[] args)
        {
            Program instance = new Program();

            
            instance.OpeningDisplay();

            bool programRunning = true;

            while (programRunning)
            {
                Console.Clear();
                Console.WriteLine("M A I N    M E N U\n" +
                    "1 - CREATE ADVENTURER\n" +
                    "2 - VIEW ADVENTURER\n" +
                    "3 - GAME SYNOPSIS\n" +
                    "4 - BEGIN GAME\n" +
                    "0 - EXIT");
                int menuChoice = Validation.GetInt(0, 4, Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        {
                            Console.Clear();
                            instance.CreateAdventurer();
                            Validation.PauseBeforeContinuing("Press any key to return to the Main Menu...");
                        }
                        break;
                    case 2:
                        {
                            Console.Clear();
                            instance.DisplayAdventurer();
                            Validation.PauseBeforeContinuing("Press any key to return to the Main Menu...");
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            Validation.PauseBeforeContinuing("Press any key to return to the Main Menu...");
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            // instance.DisplayLetterFromKing();
                            Validation.PauseBeforeContinuing("Press any key to return to the Main Menu...");
                        }
                        break;
                    case 0:
                        {
                            programRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please only enter an option corresponding with the provided options.");
                        }
                        break;
                }



            }

            
        }

        // What to display when the game starts. Need to fix file path to work on all comps
        void OpeningDisplay()
        {
            using (StreamReader inStream = new StreamReader(@"/Users/aliciajo/Desktop/Carlson_Alicia_Portfolio/FinalProject/FinalProject/FileIOInput/openingDisplay.txt"))
            {
                while (inStream.Peek() > -1)
                {
                    string line = inStream.ReadLine();
                    Console.WriteLine(line);
                }
            }

            Validation.PauseBeforeContinuing("Press any key to begin...");
            Console.Clear();
        }

        // Letter from the king. Need to fix file path to work on all comps
        void DisplayLetterFromKing()
        {
            using (StreamReader inStream = new StreamReader(@"/Users/aliciajo/Desktop/Carlson_Alicia_Portfolio/FinalProject/FinalProject/FileIOInput/scrollHeader.txt"))
            {
                while (inStream.Peek() > -1)
                {
                    string line = inStream.ReadLine();
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine("|                                                               |\n" +
                             $"| Adventurer {adventurer.Name}\n" +
                              "|       My daughter, Princess Katia, has told me of your great  |\n" +
                              "| feats. Your many victories over the fearsome creatures of our |\n" +
                              "| land. I'm calling on you now. Journey from The Wooded Valley  |\n" +
                              "| to my palace in The Town of Middle to accept my offer of      |\n" +
                              "| knighthood and the many rewards that come along with it.      |\n" +
                              "|    Be warned, you will face many creatures and unsavory       |\n" +
                              "|     persons on your journey. Make it past all of your         |\n" +
                              "|    adversaries and arrive at the castle to claim your         |\n" +
                              "|                rightful title of knight.                      |\n" +
                              "|                                                               |\n" +
                              "|                                         Good Luck             |\n" +
                              "|                                             King Modzog       |\n" +
                              "|                                                               |");

            

            using (StreamReader inStream = new StreamReader(@"/Users/aliciajo/Desktop/Carlson_Alicia_Portfolio/FinalProject/FinalProject/FileIOInput/scrollFooter.txt"))
            {
                while (inStream.Peek() > -1)
                {
                    string line = inStream.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }

        void CreateAdventurer()
        {
            if(adventurer == null)
            {
                Console.Write("Enter adventurer's name: ");
                string name = Validation.NotNullOrBlank(Console.ReadLine(), "Enter adventurer's name: ");

                adventurer = new Person(name);

                Console.WriteLine($"Health - {adventurer.Health}");
                Console.WriteLine($"Gold - {adventurer.GoldBalance}");
            }
            else
            {
                Console.WriteLine($"You have already created an adventurer.\nCreating a new adventurer will replace {adventurer.Name}\n");

                bool needAnswer = true;
                while (needAnswer)
                {
                    Console.Write("Would you like to create a new adventurer? y/n: ");
                    string answer = Validation.NotNullOrBlank(Console.ReadLine().ToLower(), "Would you like to create a new adventurer? y/n: ");

                    switch (answer)
                    {
                        case "yes":
                        case "y":
                            {
                                Console.Write("Enter adventurer's name: ");
                                string name = Validation.NotNullOrBlank(Console.ReadLine(), "Enter adventurer's name: ");

                                adventurer = new Person(name);

                                Console.WriteLine($"Health - {adventurer.Health}");
                                Console.WriteLine($"Gold - {adventurer.GoldBalance}");
                                needAnswer = false;
                            }
                            break;
                        case "no":
                        case "n":
                            {
                                Console.WriteLine($"Adventurer remains unchanged.\n" +
                                    $"Health - {adventurer.Health}\n" +
                                    $"Gold - {adventurer.GoldBalance}");
                                needAnswer = false;
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Please only answer yes or no. Try again:");
                            }
                            break;
                    }
                
                }
            }
        }

        void DisplayAdventurer()
        {
            if(adventurer != null)
            {
                adventurer.DisplayStats();
            }
            else
            {
                Console.WriteLine("An adventurer has not yet been created.\nTry creating an adventurer to view their information.");
            }
        }

        void DisplayGameSynopsis()
        {
            Console.WriteLine("Journey on a quest to accept the King's invitation of knighthood. Along your quest\n" +
                              "you will encounter many foes. Bandits and Highway Men who mean you harm can be paid\n" +
                              "off for safe passage. For the more daring adventurer, battle these foes with a game\n" +
                              "of Rock, Paper, Scissors. Win and you will be free to pass but lose and your fee for\n" +
                              "safe passage will be doubled!");
        }
    }
}
