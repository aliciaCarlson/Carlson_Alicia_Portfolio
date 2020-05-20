using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    public class NPC : Person, IPayable
    {
        int goldBalance;

        public NPC(string name) : base(name)
        {
            goldBalance = 500;
        }
    }
}
