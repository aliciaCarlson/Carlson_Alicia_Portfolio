using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    class NPC : Opponents, IPayable
    {
        // Class members
        int goldBalance;

        // Constructors (damage inherited from Opponent Class)
        public NPC(string name) : base(name)
        {
            goldBalance = 0;
            this.damage = 15;
        }

        public void DoubleForPassage(Person adventurer)
        {
            // Let user know they now have to pay double
            Console.WriteLine($"You should have taken the offer for safe passage when it was offered!\n" +
                $"{this.name} now has no interest in fighting and is demanding double the gold to safely pass this area!");
            if (adventurer.GoldBalance > 100)
            {
                Console.WriteLine($"Press any key to pay {this.name} and continue on your journey!");
                Console.ReadKey();

                adventurer.GoldBalance -= 100;
                this.goldBalance += 100;
                Console.WriteLine($"{adventurer.Name}'s gold balance is now {adventurer.GoldBalance}\n" +
                    $"{adventurer.Name} has been granted safe passage through this area by {this.name}");
            }
            else
            {
                Console.WriteLine("You don't have enough gold to pay for safe passage!\n" +
                    "Press any key to continue...");
                Console.ReadKey();
            }

        }

        public void PayForPassage(Person adventurer)
        {
            Console.WriteLine($"To avoid a fight with {this.name} you can pay 50 gold for safe passage through this area!");
            if (adventurer.GoldBalance > 50)
            {
                Console.WriteLine($"Press any key to pay {this.name}");
                Console.ReadKey();

                adventurer.GoldBalance -= 50;
                this.goldBalance += 50;

                Console.WriteLine($"{adventurer.Name}'s gold balance is now {adventurer.GoldBalance}\n" +
                    $"{adventurer.Name} has been granted safe passage through this area by {this.name}");
            }
            else
            {
                Console.WriteLine($"You don't have enough gold to pay for safe passage. You must battle in Rock Paper Scissors");
                Console.ReadKey();
            }
        }

        public void TravelersTax(Person adventurer)
        {
            Console.Write("Press enter/return to pay the travelers tax of 50 gold to enter the city: ");
            string payment = Console.ReadLine();

            switch (payment)
            {
                case "":
                    {
                        adventurer.GoldBalance -= 50;
                        this.goldBalance += 50;
                        Console.WriteLine($"{adventurer.Name}'s gold balance is now {adventurer.GoldBalance} and has been granted entry into the Town of Middle.");
                    }
                    break;
                case "show":
                    {
                        Console.WriteLine($"You show {this.name} your letter from the king and you are granted entry into the city without paying the traveler's tax.");
                    }
                    break;
                default:
                    {
                        Console.Write("Press enter/return to pay the traveler's tax of 50 gold to enter the city: ");
                    }
                    break;
            }
        }
    }
}
