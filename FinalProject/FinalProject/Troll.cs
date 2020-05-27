using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    class Troll : Opponents
    {
        public Troll(string name) : base(name)
        {
            this.damage = 25;
        }
    }
}
