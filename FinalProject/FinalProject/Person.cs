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
        public int GoldBalance { get; private set; }
        public int Health { get; private set; }

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

    }
}
