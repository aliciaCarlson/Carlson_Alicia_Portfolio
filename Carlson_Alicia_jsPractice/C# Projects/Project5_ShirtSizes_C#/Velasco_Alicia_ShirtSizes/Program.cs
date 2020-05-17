using System;

namespace Velasco_Alicia_ShirtSizes
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Alicia Velasco
             * SDI 1910 - Section 01
             * 10 / 19 / 19
             * Assignment : Shirt Size Sorter
             */

            // Greet the user and tell them what we are doing
            Console.WriteLine("Hey there! We need to order shirts for our bowling team and need to know\r\n" +
                "how many of each size we are going to need.\r\nThis program will tell you exactly how much to order!\r\n");

            //Declare first array
            string[] shirtOrder = new string [] {"Medium", "Small", "X-Large", "Small", "Large", "Medium", "Small", "X-Large", "XX-Large"};

            //Declare second array
            //string[] shirtOrder = new string[] {"XX-Large", "Medium", "Large", "Small", "X-Large", "Small", "Large", "XX-Large", "Large", "XX-Large", "Medium", "Medium"};

            //Declare variables to hold each size total
            int small = 0;
            int medium = 0;
            int large = 0;
            int xLarge = 0;
            int xxLarge = 0;

            //Create for loop to cycle through array
            for (int i = 0; i < shirtOrder.Length; i++)
            {
                //Use conditional block to add up totals
                // if loop gets to a size Small add 1 to small total
                if (shirtOrder[i] == "Small")
                {
                    small += 1;
                }
                //if loop gets to a size Medium and 1 to medium total
                else if (shirtOrder[i] == "Medium")
                {
                    medium += 1;
                }
                //if loop gets to a size Large add 1 to large total
                else if (shirtOrder[i] == "Large")
                {
                    large += 1;
                }
                //if loop gets to a size X-Large add 1 to xLarge total
                else if (shirtOrder[i] == "X-Large")
                {
                    xLarge += 1;
                }
                //if loop gets to a size XX-Large add 1 to xxLarge total
                else if (shirtOrder[i] == "XX-Large")
                {
                    xxLarge += 1;
                }

            }

            //Report back to the user the results
            Console.WriteLine("Order " + small + " Small Shirts(s).\r\n" +
                "Order " + medium + " Medium Shirt(s).\r\n" +
                "Order " + large + " Large Shirt(s).\r\n" +
                "Order " + xLarge + " X-Large Shirt(s).\r\n" +
                "Order " + xxLarge + " XX-Large Shirt(s).");

            //Thank the user for using the program
            Console.WriteLine("\r\nThank you for using this program to find out how many of each size you need\r\nto order! Just let your shirt supplier know this information and you're good to go!");


            //Shirt Size Sorter Test
            /* TEST 1 : First Array
             * Results :
             * Order 3 Small Shirts(s).
                Order 2 Medium Shirt(s).
                Order 1 Large Shirt(s).
                Order 2 X-Large Shirt(s).
                Order 1 XX-Large Shirt(s).
             *
             * TEST 2 : Second Array
             * Results :
             * Order 2 Small Shirts(s).
                Order 3 Medium Shirt(s).
                Order 3 Large Shirt(s).
                Order 1 X-Large Shirt(s).
                Order 3 XX-Large Shirt(s).
             */


        }
    }
}
