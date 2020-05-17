using System;

namespace ZombieLoopingMadness
{
    class Program
    {
        static void Main(string[] args)
        {
            //Zombie Madness

            //Givens first
            //Start with 1 zombie
            //Can bite 4 people in a day
            //8 days?

            //Turn into variables

            //How many zombies do we have?
            int numZombies = 1;

            //Number of bites per zombie per day
            int numBites = 4;

            //Number of days
            int days = 8;

            //Create for loop to cycle through each day
            for (int i = 1; i <= days; i++)
            {
                //What happens in 1 day?

                //How many new zombies get created?
                //number of bites * number of zombies
                int newZombies = numZombies * numBites;

                //End of day the new zombies join the zombie hoard
                //update number of zombies
                numZombies += newZombies;

                //Tell the public how many zombies we have each day
                Console.WriteLine("There are {0} zombies on day #{1}!", numZombies, i);


            }


            //How long it will take to reach a million zombies?

            int numDays = 1;

            int zombieHordeNumber = 1;

            while (zombieHordeNumber <= 1000000)
            {
                //Happens each day
                int bittenPeople = zombieHordeNumber * numBites;

                //End of day those people become zombies
                zombieHordeNumber += bittenPeople;

                //Report to the people how many zombies there are.
                Console.WriteLine("On day #{0}, there are {1} zombies!", numDays, zombieHordeNumber);

                //End of the day, we increase the day number by 1!
                numDays++;
            }




        }
    }
}
