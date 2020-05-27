using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    class Giant : Opponents
    {
        public Giant(string name) : base(name)
        {
            this.damage = 40;
        }
    }
}
