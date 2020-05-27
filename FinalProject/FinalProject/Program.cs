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
        Opponents opponent = null;
        Opponents highwayMen = new NPC("Highway Men");
        Opponents bandits = new NPC("Bandits");
        Opponents troll = new Troll("Troll");
        Opponents giant = new Giant("Giant");
        Opponents travelTax = new NPC("Gate Guard");

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
                            instance.DisplayGameSynopsis();
                            Validation.PauseBeforeContinuing("Press any key to return to the Main Menu...");
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            instance.DisplayLetterFromKing();
                            Validation.PauseBeforeContinuing("Press any key to continue...");
                            Console.Clear();
                            instance.Day1();
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

        // What to display when the game starts.
        void OpeningDisplay()
        {
            using (StreamReader inStream = new StreamReader(@"../../../FileIOInput/openingDisplay.txt"))
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

        // Letter from the king.
        void DisplayLetterFromKing()
        {
            using (StreamReader inStream = new StreamReader(@"../../../FileIOInput/scrollHeader.txt"))
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

            

            using (StreamReader inStream = new StreamReader(@"../../../FileIOInput/scrollFooter.txt"))
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

        void EncounterOpponent()
        {
            int winnerCode = 0;
            int gamesPlayed = 0;
            if (opponent is IPayable)
            {
                Console.Write("Would you like to\n" +
                    "1 - Pay for safe passage\n" +
                    "2 - Battle with Rock, Paper, Scissors\n" +
                    "Enter your choice: ");
                string answer = Validation.NotNullOrBlank(Console.ReadLine().ToLower(), "Enter your choice: ");

                switch (answer)
                {
                    case "1":
                    case "pay":
                        {
                            ((IPayable)opponent).PayForPassage(adventurer);
                        }
                        break;
                    case "2":
                    case "battle":
                        {
                            winnerCode = Battle();
                            if(winnerCode != 1)
                            {
                                ((IPayable)opponent).DoubleForPassage(adventurer);
                            }
                        }
                        break;
                }
            }
            else
            {
                while(winnerCode != 1 && gamesPlayed < 3)
                {
                    winnerCode = Battle();
                    gamesPlayed += 1;
                }
                if(gamesPlayed == 3)
                {
                    Console.WriteLine($"You have weakened the {opponent.name} enough to defeat it!");
                }
            }
            
        }

        int Battle()
        {
            int winnerCode = 0;
            int adventurerHand = adventurer.ThrowHand();
            int opponentHand = opponent.ThrowHand();

            switch (adventurerHand)
            {
                case 1:
                    {
                        switch (opponentHand)
                        {
                            case 1:
                                {
                                    Console.WriteLine("It's a tie!");
                                    winnerCode = 3;
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine($"{opponent.name} has won!");
                                    winnerCode = 2;
                                    adventurer.Health -= opponent.damage;
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine($"{adventurer.Name} has won!");
                                    winnerCode = 1;
                                    break;
                                }
                        }

                        break;
                    }
                case 2:
                    {
                        switch (opponentHand)
                        {
                            case 1:
                                {
                                    Console.WriteLine($"{adventurer.Name} has won!");
                                    winnerCode = 1;
                                    break;
                                }
                        case 2:
                            {
                                Console.WriteLine($"It's a tie!");
                                winnerCode = 3;
                                break;
                                }
                            case 3:
                                {
                                Console.WriteLine($"{opponent.name} has won!");
                                winnerCode = 2;
                                adventurer.Health -= opponent.damage;
                                break;
                                }
                        }

                        break;
                    }
                case 3:
                    {
                        switch (opponentHand)
                        {
                            case 1:
                                {
                                    Console.WriteLine($"{opponent.name} has won!");
                                    winnerCode = 2;
                                    adventurer.Health -= opponent.damage;
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine($"{adventurer.Name} has won!");
                                    winnerCode = 1;
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine($"It's a tie!");
                                    winnerCode = 3;
                                    break;
                                }
                        }

                        break;
                    }


            }

            Console.WriteLine();
            return winnerCode;
        }

        void GameOver()
        {
            Console.Clear();
            Console.WriteLine("You don't have enough health or gold to continue on your journey.\n" +
                "Create a new adventurer and try again!");
            adventurer = null;
            Validation.PauseBeforeContinuing();
        }

        void Day1()
        {
            Console.WriteLine("D A Y  1\n" +
                "You embark on your journey. The terrain is mild. You don't encounter\n" +
                $"any foes. You end the day with {adventurer.Health} Health & {adventurer.GoldBalance} Gold");
            Validation.PauseBeforeContinuing("Press any key to continue...\n");
            Console.Clear();
            Day2();
        }

        void Day2()
        {
            opponent = highwayMen;
            Console.WriteLine($"D A Y  2\n" +
                $"You awake at sunrise and set out. Mid-day you are met by {opponent.name}. You can choose to\n" +
                $"pay or fight.\n");
            EncounterOpponent();
            if (adventurer.Health > 40 && adventurer.GoldBalance > 50)
            {
                Console.WriteLine($"\nAt dusk you make camp. You end the day with {adventurer.Health} Health & {adventurer.GoldBalance} Gold");
                Validation.PauseBeforeContinuing("Press any key to continue...\n");
                Console.Clear();
                Day3();
            }
            else
            {
                GameOver();
            }
            
           
        }

        void Day3()
        {
            opponent = troll;
            Console.WriteLine($"D A Y  3\n" +
                $"You awake to an unknown sound! There's a {opponent.name} in your camp! You must fight him off...\n");
            EncounterOpponent();
            if (adventurer.Health > 40 && adventurer.GoldBalance > 50)
            {
                Console.WriteLine($"\nYou continue on your journey without further encounters today. You end the day with {adventurer.Health} Health & {adventurer.GoldBalance} Gold");
                Validation.PauseBeforeContinuing("Press any key to continue...\n");
                Console.Clear();
                Day4();
            }
            else
            {
                GameOver();
            }
        }

        void Day4()
        {
            opponent = giant;
            Console.WriteLine($"D A Y  4\n" +
                $"You awake at dawn and set out. You take a mountain pass. You've saved yourself 2 days of traveling\n" +
                $"but have to pass through a {opponent.name}'s camp. You must fight the {opponent.name}...\n");
            EncounterOpponent();
            if (adventurer.Health > 40 && adventurer.GoldBalance > 50)
            {
                Console.WriteLine($"\nYou continue on your journey and make camp in a mountain cave.\n" +
                    $"You end the day with {adventurer.Health} Health & {adventurer.GoldBalance} Gold");
                Validation.PauseBeforeContinuing("Press any key to continue...\n");
                Console.Clear();
                Day5();
            }
            else
            {
                GameOver();
            }
        }

        void Day5()
        {
            opponent = bandits;
            Console.WriteLine($"You awaken mid-morning and continue on your quest. By mid-afternoon you begin to see the outline of the castle\n" +
                $"on the horizon. At dusk you are approached by {opponent.name}. You can pay or fight...\n");
            EncounterOpponent();
            if (adventurer.Health > 40 && adventurer.GoldBalance > 50)
            {
                Console.WriteLine($"\nYou continue a few miles and make camp. You will reach your destination tomorrow! You end the day\n" +
                    $"with {adventurer.Health} Health & {adventurer.GoldBalance} Gold");
                Validation.PauseBeforeContinuing("Press any key to continue...\n");
                Console.Clear();
                Day6();
            }
            else
            {
                GameOver();
            }
        }

        void Day6()
        {
            opponent = travelTax;
            Console.WriteLine($"You awaken before sunrise eager to arrive at the castle. You set off while it's still dark. The land around the\n" +
                $"Town of Middle is well patroled by the town guards. Mid-day you arrive at the town gates.\n" +
                $"There is a travelers tax and you must pay 50 gold to enter the city.");
            ((IPayable)opponent).TravelersTax(adventurer);
            Console.WriteLine($"\nYou enter the city with {adventurer.Health} Health & {adventurer.GoldBalance} Gold.");
            Validation.PauseBeforeContinuing("Press any key to continue...\n");
            Console.Clear();
            FileIO();
        }

        void FileIO()
        {
            Console.WriteLine("You've arrived at the castle. You enter the King's Throne Room where he congratulates you.\n" +
                $"You are knighted and presented with an offical decree. See {adventurer.Name}{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt in the Decrees folder to view your decree!");

            string path = $@"../../../Decrees/{adventurer.Name}{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            string stringToSave = $"Adventurer {adventurer.Name}\n" +
                $"Ending Health: {adventurer.Health}\n" +
                $"Ending Gold: {adventurer.GoldBalance}\n" +
                $"This decree is to certify that Adventurer {adventurer.Name} is now Knight {adventurer.Name}\n" +
                $"by offical order of King Modzog!";
            File.WriteAllText(path, stringToSave);
            adventurer = null;
            Validation.PauseBeforeContinuing();
        }
    }
}
