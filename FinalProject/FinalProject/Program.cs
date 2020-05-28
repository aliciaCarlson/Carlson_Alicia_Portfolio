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
        //Instantiate all the object variables that are going to be used throughout the program
        Person adventurer = null;
        Opponents opponent = null;
        Opponents highwayMen = new NPC("Highway Men");
        Opponents bandits = new NPC("Bandits");
        Opponents troll = new Troll("Troll");
        Opponents giant = new Giant("Giant");
        Opponents travelTax = new NPC("Gate Guard");

        static void Main(string[] args)
        {
            // Instantiate an instance of the prgram class to reduce static methods.
            Program instance = new Program();

            // Display the opening 'A Quest for Knighthood'
            instance.OpeningDisplay();
            // Boolean and while loop to keep the menu running until user chooses to exit
            bool programRunning = true;
            
            while (programRunning)
            {
                // Clear the console and display the menu
                Console.Clear();
                Console.WriteLine("M A I N    M E N U\n" +
                    "1 - CREATE ADVENTURER\n" +
                    "2 - VIEW ADVENTURER\n" +
                    "3 - GAME SYNOPSIS\n" +
                    "4 - BEGIN GAME\n" +
                    "0 - EXIT");
                // Get the menu choice the user makes and parse to an int
                int menuChoice = Validation.GetInt(0, 4, Console.ReadLine());

                // Switch to execute the proper function depending on user choice
                switch (menuChoice)
                {
                    case 1:
                        {
                            // Call the CreateAdventurer method
                            Console.Clear();
                            instance.CreateAdventurer();
                            Validation.PauseBeforeContinuing("Press any key to return to the Main Menu...");
                        }
                        break;
                    case 2:
                        {
                            // Call the DisplayAdventurer method
                            Console.Clear();
                            instance.DisplayAdventurer();
                            Validation.PauseBeforeContinuing("Press any key to return to the Main Menu...");
                        }
                        break;
                    case 3:
                        {
                            // Call the DisplayGameSynopsis method
                            Console.Clear();
                            instance.DisplayGameSynopsis();
                            Validation.PauseBeforeContinuing("Press any key to return to the Main Menu...");
                        }
                        break;
                    case 4:
                        {
                            // if statement to make sure game doesn't try to start without having an adventurer
                            if (instance.adventurer != null)
                            {
                                // Call the DisplayLetterFromKing method
                                Console.Clear();
                                instance.DisplayLetterFromKing();
                                Validation.PauseBeforeContinuing("Press any key to continue...");
                                // Call Day1 method to begin game
                                Console.Clear();
                                instance.Day1();
                                Validation.PauseBeforeContinuing("Press any key to return to the Main Menu...");
                            }
                            else
                            {
                                // Let user know they need an adventurer
                                Console.WriteLine("No adventurer created. Create an adventurer before trying to play!");
                            }
                        }
                        break;
                    case 0:
                        {
                            // Changes bool to false to quit displaying menu
                            programRunning = false;
                        }
                        break;
                    default:
                        {
                            // Will display if an invalid option is choosen
                            Console.WriteLine("Please only enter an option corresponding with the provided options.");
                        }
                        break;
                }



            }

            
        }

        // What to display when the game starts.
        void OpeningDisplay()
        {
            // Reading the file in with FileIO
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
            // Reading in the top of scroll with FileIO
            using (StreamReader inStream = new StreamReader(@"../../../FileIOInput/scrollHeader.txt"))
            {
                while (inStream.Peek() > -1)
                {
                    string line = inStream.ReadLine();
                    Console.WriteLine(line);
                }
            }

            // Output the letter with string interpolation to insert users name
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

            
            // Reading in the bottom of scroll with FileIO
            using (StreamReader inStream = new StreamReader(@"../../../FileIOInput/scrollFooter.txt"))
            {
                while (inStream.Peek() > -1)
                {
                    string line = inStream.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }

        // Create an adventurer
        void CreateAdventurer()
        {
            // Checking to see if an adventurer has already been created
            if(adventurer == null)
            {
                // Prompting for name from user
                Console.Write("Enter adventurer's name: ");
                // Getting user's input with validation to make sure something was entered
                string name = Validation.NotNullOrBlank(Console.ReadLine(), "Enter adventurer's name: ");

                // Assigning a value to the adventurer using user input
                adventurer = new Person(name);

                // Outputing the adventurer's stats to the user
                Console.WriteLine($"Health - {adventurer.Health}");
                Console.WriteLine($"Gold - {adventurer.GoldBalance}");
            }
            else
            {
                // Letting the user know there is already a user created
                Console.WriteLine($"You have already created an adventurer.\nCreating a new adventurer will replace {adventurer.Name}\n");

                // Boolean and while loop to keep asking question until a vaild answer is entered
                bool needAnswer = true;
                while (needAnswer)
                {
                    // Asking the user if they want to create a new user
                    Console.Write("Would you like to create a new adventurer? y/n: ");
                    // Getting user's input with validation to make sure something was entered
                    string answer = Validation.NotNullOrBlank(Console.ReadLine().ToLower(), "Would you like to create a new adventurer? y/n: ");

                    // Switch to execute the proper function depending on user choice
                    switch (answer)
                    {
                        case "yes":
                        case "y":
                            {
                                // Prompting for name
                                Console.Write("Enter adventurer's name: ");
                                // Getting name with validation that it's not blank
                                string name = Validation.NotNullOrBlank(Console.ReadLine(), "Enter adventurer's name: ");

                                // Assigning a value to the adventurer using user input
                                adventurer = new Person(name);

                                // Ouputting the adventurer's stats to the user
                                Console.WriteLine($"Health - {adventurer.Health}");
                                Console.WriteLine($"Gold - {adventurer.GoldBalance}");
                                // Changing bool to false the the question won't be asked again
                                needAnswer = false;
                            }
                            break;
                        case "no":
                        case "n":
                            {
                                // Letting the user know that their adventurer was not changed and displaying adventurer to user
                                Console.WriteLine($"Adventurer remains unchanged.\n" +
                                    $"Adventurer - {adventurer.Name}\n" +
                                    $"Health - {adventurer.Health}\n" +
                                    $"Gold - {adventurer.GoldBalance}");
                                // Changing bool to false the the question won't be asked again
                                needAnswer = false;
                            }
                            break;
                        default:
                            {
                                // Will output if an invalid option is entered
                                Console.WriteLine("Please only answer yes or no. Try again:");
                            }
                            break;
                    }
                
                }
            }
        }

        // Display the current adventurer and their stats
        void DisplayAdventurer()
        {
            // Check to see ifadventurer is not null
            if(adventurer != null)
            {
                // Call the method to display stats from current instance of adventurer
                adventurer.DisplayStats();
            }
            // else(adventurer is null)
            else
            {
                // Let the user know there isn't an adventurer to display stats for
                Console.WriteLine("An adventurer has not yet been created.\nTry creating an adventurer to view their information.");
            }
        }

        // Display a synopsis of the game
        void DisplayGameSynopsis()
        {
            // Output a synopsis of the game
            Console.WriteLine("Journey on a quest to accept the King's invitation of knighthood. Along your quest\n" +
                              "you will encounter many foes. Bandits and Highway Men who mean you harm can be paid\n" +
                              "off for safe passage. For the more daring adventurer, battle these foes with a game\n" +
                              "of Rock, Paper, Scissors. Win and you will be free to pass but lose and your fee for\n" +
                              "safe passage will be doubled!");
        }

        // Method of encontering an opponent
        void EncounterOpponent()
        {
            // variable assigned to game depending on winner (1-adventurer wins 2-opponent wins 3-tie)
            int winnerCode = 0;
            // variable to keep track of number of games played
            int gamesPlayed = 0;
            // if statement to check if the opponent is IPayable
            if (opponent is IPayable)
            {
                // Give the user the option to pay for safe passage
                Console.Write("Would you like to\n" +
                    "1 - Pay for safe passage\n" +
                    "2 - Battle with Rock, Paper, Scissors\n" +
                    "Enter your choice: ");
                // Get the user response with validation that it's not blank
                string answer = Validation.NotNullOrBlank(Console.ReadLine().ToLower(), "Enter your choice: ");

                // switch to execute correct option depending on user's answer
                switch (answer)
                {
                    case "1":
                    case "pay":
                        {
                            // calling the pay for passage method from NPC class
                            ((IPayable)opponent).PayForPassage(adventurer);
                        }
                        break;
                    case "2":
                    case "battle":
                        {
                            // calling battle and storing the returned value in winnerCode variable
                            winnerCode = Battle();
                            // If statement for if user looses RPS
                            if(winnerCode != 1)
                            {
                                // calling the double for passage method from NPC class
                                ((IPayable)opponent).DoubleForPassage(adventurer);
                            }
                        }
                        break;
                }
            }
            // else for if opponent isn't payable (giant, troll)
            else
            {
                // while loop to keep battle going if adventurer loses and games played is less than 3
                while(winnerCode != 1 && gamesPlayed < 3)
                {
                    // calling battle and storing the returned value in winnerCode variable
                    winnerCode = Battle();
                    // increasing the games played by 1
                    gamesPlayed += 1;
                }
                // if statement to display output when games played reaches 3
                if(gamesPlayed == 3)
                {
                    // letting the user know why they no longer have to fight even if they lose all
                    Console.WriteLine($"You have weakened the {opponent.name} enough to defeat it!");
                }
            }
            
        }

        // Method for adventurer and opponent to battle in RPS
        int Battle()
        {
            // variable assigned to game depending on winner (1-adventurer wins 2-opponent wins 3-tie)
            int winnerCode = 0;
            // calling ThrowHand method from person class to get the hand the user wants to play. Tracked by number (1-Rock 2-Paper 3-Scissors)
            int adventurerHand = adventurer.ThrowHand();
            // calling ThrowHand method from opponent class to get the hand the opponent throws. Tracked by number (1-Rock 2-Paper 3-Scissors)
            int opponentHand = opponent.ThrowHand();

            // Switch to calculate winner based on values of each hand thrown
            switch (adventurerHand)
            {
                // user played Rock
                case 1:
                    {
                        switch (opponentHand)
                        {
                            // opponent threw Rock
                            case 1:
                                {
                                    Console.WriteLine("It's a tie!");
                                    winnerCode = 3;
                                    break;
                                }
                            // opponent threw Paper
                            case 2:
                                {
                                    Console.WriteLine($"{opponent.name} has won!");
                                    winnerCode = 2;
                                    // adventurer takes damage since lost
                                    adventurer.Health -= opponent.damage;
                                    break;
                                }
                            // opponent threw Scissors
                            case 3:
                                {
                                    Console.WriteLine($"{adventurer.Name} has won!");
                                    winnerCode = 1;
                                    break;
                                }
                        }

                        break;
                    }
                // user played Paper
                case 2:
                    {
                        switch (opponentHand)
                        {
                            // opponent threw Rock
                            case 1:
                                {
                                    Console.WriteLine($"{adventurer.Name} has won!");
                                    winnerCode = 1;
                                    break;
                                }
                            // opponent threw Paper
                            case 2:
                            {
                                Console.WriteLine($"It's a tie!");
                                winnerCode = 3;
                                break;
                                }
                            // opponent threw Scissors
                            case 3:
                                {
                                Console.WriteLine($"{opponent.name} has won!");
                                winnerCode = 2;
                                // adventurer takes damage since lost
                                adventurer.Health -= opponent.damage;
                                break;
                                }
                        }

                        break;
                    }
                // user played Scissors
                case 3:
                    {
                        switch (opponentHand)
                        {
                            // opponent threw Rock
                            case 1:
                                {
                                    Console.WriteLine($"{opponent.name} has won!");
                                    winnerCode = 2;
                                    // adventurer takes damage since lost
                                    adventurer.Health -= opponent.damage;
                                    break;
                                }
                            // opponent threw Paper
                            case 2:
                                {
                                    Console.WriteLine($"{adventurer.Name} has won!");
                                    winnerCode = 1;
                                    break;
                                }
                            // opponent threw Scissors
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
            // return the winner code to use in encounter opponent
            return winnerCode;
        }

        // What to display if user loses
        void GameOver()
        {
            Console.Clear();
            // Letting the user know they don't have enough health or gold to continue
            Console.WriteLine("You don't have enough health or gold to continue on your journey.\n" +
                "Create a new adventurer and try again!");
            // reset adventurer to null
            adventurer = null;
            Validation.PauseBeforeContinuing();
        }

        // Method for day1
        void Day1()
        {
            // Ouput day one story
            Console.WriteLine("D A Y  1\n" +
                "You embark on your journey. The terrain is mild. You don't encounter\n" +
                $"any foes. You end the day with {adventurer.Health} Health & {adventurer.GoldBalance} Gold");
            Validation.PauseBeforeContinuing("Press any key to continue...\n");
            Console.Clear();
            // call Day 2 method
            Day2();
        }

        void Day2()
        {
            // Setting opponent to highwayMen
            opponent = highwayMen;
            // Output story for day 2
            Console.WriteLine($"D A Y  2\n" +
                $"You awake at sunrise and set out. Mid-day you are met by {opponent.name}. You can choose to\n" +
                $"pay or fight.\n");
            // Call EncounterOpponent to initiate pay or fight
            EncounterOpponent();
            // If statement to check adventurers stats to determine if they have enough to go to next day
            if (adventurer.Health > 40 && adventurer.GoldBalance > 50)
            {
                // Finish day 2 story
                Console.WriteLine($"\nAt dusk you make camp. You end the day with {adventurer.Health} Health & {adventurer.GoldBalance} Gold");
                Validation.PauseBeforeContinuing("Press any key to continue...\n");
                Console.Clear();
                // Call Day3
                Day3();
            }
            else
            {
                // Display GameOver method if adventurer doesn't have enough for next day
                GameOver();
            }
            
           
        }

        void Day3()
        {
            // Setting opponent to troll
            opponent = troll;
            // Output story for day 3
            Console.WriteLine($"D A Y  3\n" +
                $"You awake to an unknown sound! There's a {opponent.name} in your camp! You must fight him off...\n");
            // Call EncounterOpponent to initiate pay or fight
            EncounterOpponent();
            // If statement to check adventurers stats to determine if they have enough to go to next day
            if (adventurer.Health > 40 && adventurer.GoldBalance > 50)
            {
                // Finish day 3 story
                Console.WriteLine($"\nYou continue on your journey without further encounters today. You end the day with {adventurer.Health} Health & {adventurer.GoldBalance} Gold");
                Validation.PauseBeforeContinuing("Press any key to continue...\n");
                Console.Clear();
                // Call Day4
                Day4();
            }
            else
            {
                // Display GameOver method if adventurer doesn't have enough for next day
                GameOver();
            }
        }

        void Day4()
        {
            // Setting opponent to giant
            opponent = giant;
            // Output story for day 4
            Console.WriteLine($"D A Y  4\n" +
                $"You awake at dawn and set out. You take a mountain pass. You've saved yourself 2 days of traveling\n" +
                $"but have to pass through a {opponent.name}'s camp. You must fight the {opponent.name}...\n");
            // Call EncounterOpponent to initiate pay or fight
            EncounterOpponent();
            // If statement to check adventurers stats to determine if they have enough to go to next day
            if (adventurer.Health > 40 && adventurer.GoldBalance > 50)
            {
                // Finish day 4 story
                Console.WriteLine($"\nYou continue on your journey and make camp in a mountain cave.\n" +
                    $"You end the day with {adventurer.Health} Health & {adventurer.GoldBalance} Gold");
                Validation.PauseBeforeContinuing("Press any key to continue...\n");
                Console.Clear();
                // Call Day5
                Day5();
            }
            else
            {
                // Display GameOver method if adventurer doesn't have enough for next day
                GameOver();
            }
        }

        void Day5()
        {
            // Setting opponent to bandits
            opponent = bandits;
            // Output story for day 5
            Console.WriteLine($"D A Y  5" +
                $"You awaken mid-morning and continue on your quest. By mid-afternoon you begin to see the outline of the castle\n" +
                $"on the horizon. At dusk you are approached by {opponent.name}. You can pay or fight...\n");
            // Call EncounterOpponent to initiate pay or fight
            EncounterOpponent();
            // If statement to check adventurers stats to determine if they have enough to go to next day
            if (adventurer.Health > 40 && adventurer.GoldBalance > 50)
            {
                // Finish day 5 story
                Console.WriteLine($"\nYou continue a few miles and make camp. You will reach your destination tomorrow! You end the day\n" +
                    $"with {adventurer.Health} Health & {adventurer.GoldBalance} Gold");
                Validation.PauseBeforeContinuing("Press any key to continue...\n");
                Console.Clear();
                // Call Day6
                Day6();
            }
            else
            {
                // Display GameOver method if adventurer doesn't have enough for next day
                GameOver();
            }
        }

        void Day6()
        {
            // Setting opponent to travelTax(gate guard)
            opponent = travelTax;
            // Output story for day 6
            Console.WriteLine($"You awaken before sunrise eager to arrive at the castle. You set off while it's still dark. The land around the\n" +
                $"Town of Middle is well patroled by the town guards. Mid-day you arrive at the town gates.\n" +
                $"There is a travelers tax and you must pay 50 gold to enter the city.");
            // Call NPC class method to travelers tax
            ((IPayable)opponent).TravelersTax(adventurer);
            // Output users stats when they enter the city (ending stats)
            Console.WriteLine($"\nYou enter the city with {adventurer.Health} Health & {adventurer.GoldBalance} Gold.");
            Validation.PauseBeforeContinuing("Press any key to continue...\n");
            Console.Clear();
            // Call FileIO method to create user's decree of knighthood
            FileIO();
        }

        void FileIO()
        {
            // Let the user know they've one
            Console.WriteLine("You've arrived at the castle. You enter the King's Throne Room where he congratulates you.\n" +
                $"You are knighted and presented with an offical decree. See {adventurer.Name}{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt in the Decrees folder to view your decree!");

            // Create file path to save decree too
            string path = $@"../../../Decrees/{adventurer.Name}{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            // Create what will be saved to .txt doc
            string stringToSave = $"Adventurer {adventurer.Name}\n" +
                $"Ending Health: {adventurer.Health}\n" +
                $"Ending Gold: {adventurer.GoldBalance}\n" +
                $"This decree is to certify that Adventurer {adventurer.Name} is now Knight {adventurer.Name}\n" +
                $"by offical order of King Modzog!";
            // Send output to destination from file path
            File.WriteAllText(path, stringToSave);
            // Set adventurer to null since game complete
            adventurer = null;
            Validation.PauseBeforeContinuing();
        }
    }
}
