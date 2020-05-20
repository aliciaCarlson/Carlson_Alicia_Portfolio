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
        static void Main(string[] args)
        {
            OpeningDisplay();
        }

        public static void OpeningDisplay()
        {
            using (StreamReader inStream = new StreamReader(@"/Users/aliciajo/Desktop/Carlson_Alicia_Portfolio/FinalProject/FinalProject/openingDisplay.txt"))
            {
                while (inStream.Peek() > -1)
                {
                    string line = inStream.ReadLine();
                    Console.WriteLine(line);
                }
            }

            Validation.PauseBeforeContinuing("Press any key to begin...");
        }
    }
}
