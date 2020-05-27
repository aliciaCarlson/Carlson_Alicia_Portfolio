using System;
namespace FinalProject
{
    abstract class Opponents
    {
        public string name { get; private set; }
        public int damage { get; set; }

        public Opponents(string _name)
        {
            name = _name;
        }

        public int ThrowHand()
        {
            int handTrown = 0;

            Random random = new Random();
            handTrown = random.Next(1, 4);

            switch (handTrown)
            {
                case 1:
                    {
                        Console.WriteLine($"{this.name} has thrown Rock.");
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine($"{this.name} has thrown Paper.");
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine($"{this.name} has thrown Scissors.");
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Valid number was not thrown");
                    }
                    break;
            }

            return handTrown;
        }
    }
}
