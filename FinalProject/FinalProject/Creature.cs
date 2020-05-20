using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    abstract class Creature
    {
        string name;
        int health;

        public Creature(string _name, int _health)
        {
            name = _name;
            health = _health;
        }
    }
}
