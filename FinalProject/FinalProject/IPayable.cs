using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    public interface IPayable
    {

        void PayForPassage(Person adventurer);

        void DoubleForPassage(Person adventurer);

        void TravelersTax(Person adventurer);
    }
}
