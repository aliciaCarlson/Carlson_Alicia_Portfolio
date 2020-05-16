using System;

namespace Velasco_Alicia_GroceryCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Alicia Velasco
             * 1910 Section 01
             * Grocery Calculator Assignment
             * 10 / 6 / 19
             */

            // Starting by telling the user what we are doing
            Console.WriteLine("We need to get some things from the store!\r\n" +
                "On our list is Banana, Beef Brisket and Apple Pie.\r\n");

            // Prompting the user for the price of banana
            Console.WriteLine("Let's start with bananas. How much does one cost?");
            // Listen for users response
            string bananaCostString = Console.ReadLine();
            // Convert string to decimal
            decimal bananaCostNumber = decimal.Parse(bananaCostString);

            // Prompting the user for the number of bananas to buy
            Console.WriteLine("How many bananas do we need to buy?");
            // Listen for users response
            string bananaQuantString = Console.ReadLine();
            // Convert string to number datatype
            decimal bananaQuantNumber = decimal.Parse(bananaQuantString);

            // Calculating total cost of bananas
            decimal totalBananaCost = bananaCostNumber * bananaQuantNumber;
            // Outputting total cost of bananas to user
            Console.WriteLine("The total cost for bananas is $" + totalBananaCost);


            // Promting the user for the price of beef brisket
            Console.WriteLine("Next we need beef brisket. How much does one cost?");
            // Listen for users response
            string brisketCostString = Console.ReadLine();
            // Convert string to decimal
            decimal brisketCostNumber = decimal.Parse(brisketCostString);

            // Prompting the user for the number of briskets to buy
            Console.WriteLine("How many briskets do we need to buy?");
            // Listen for users response
            string brisketQuantString = Console.ReadLine();
            // Convert string to number datatype
            decimal brisketQuantNumber = decimal.Parse(brisketQuantString);

            // Calulating total cost of briskets
            decimal totalBrisketCost = brisketCostNumber * brisketQuantNumber;
            // Outputting total cost of briskets to user
            Console.WriteLine("The total cost for briskets is $" + totalBrisketCost);




            // Prompting the user for the price of apple pie
            Console.WriteLine("Lastly, we need apple pie. How much does one pie cost?");
            // Listen for users response
            string pieCostString = Console.ReadLine();
            // Convert string to decimal
            decimal pieCostNumber = decimal.Parse(pieCostString);

            // Prompting the user for the number of apple pies to buy
            Console.WriteLine("How many apple pies do we need to buy?");
            // Listen for users response
            string pieQuantString = Console.ReadLine();
            // Conver string to number datatype
            decimal pieQuantNumber = decimal.Parse(pieQuantString);

            // Calculating total cost of pies
            decimal totalPieCost = pieCostNumber * pieQuantNumber;
            // Outputting total cost of pies to user
            Console.WriteLine("The total cost of pies is $" + totalPieCost);

            // Calculating subtotal (total before tax)
            decimal subtotal = totalBananaCost + totalBrisketCost + totalPieCost;

            // Calculating tax
            // Prompting the user to enter the sales tax % in their area
            Console.WriteLine("What is the sales tax in your area? Enter as whole number only, ex. if 6% enter 6");
            // Listen for user's response
            string taxWholeString = Console.ReadLine();
            // Convert string to decimal
            decimal taxWholeNumber = decimal.Parse(taxWholeString);
            // Convert tax whole number to percentage decimal
            decimal taxPercentNumber = taxWholeNumber / 100;
            // Calculating total tax amount for purchase
            decimal totalTax = taxPercentNumber * subtotal;


            // Calculating grand total
            decimal grandTotal = subtotal + totalTax;

            // Outputting final values to the user (subtotal, tax, and grand total)
            Console.WriteLine("The subtotal is $" + subtotal);
            Console.WriteLine("The total tax is $" + totalTax);
            Console.WriteLine("The grand total is $" + grandTotal);


            /* Test 1
             * Bananas
             *      Cost - 0.40
             *      Quantity - 4
             *
             * Beef Brisket
             *      Cost - 20.25
             *      Quantity - 2
             *
             * Apple Pie
             *      Cost - 9.75
             *      Quantity - 3
             *
             * Sales tax in my area - 5%
             *
             * Results
             * The total cost for bananas is $1.60
             * The total cost for briskets is $40.50
             * The total cost of pies is $29.255
             * The subtotal is $71.35
             * The total tax is $3.5675
             * The grand total is $74.9175
             */


            /* Test 2
             * Bananas
             *      Cost - 0.75
             *      Quantity - 6
             *
             * Beef Brisket
             *      Cost - 13.24
             *      Quantity - 4
             *
             * Apple Pie
             *      Cost - 3.75
             *      Quantity - 2
             *
             * Sales tax in my area - 9%
             *
             * Results
             * The total cost for bananas is $4.50
             * The total cost for briskets is $52.96
             * The total cost of pies is $7.50
             * The subtotal is $64.96
             * The total tax is $5.8464
             * The grand total is $70.8064
             */






        }
    }
}
