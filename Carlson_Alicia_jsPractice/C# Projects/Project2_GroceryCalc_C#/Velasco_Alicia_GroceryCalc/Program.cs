using System;
using System.Collections.Generic;

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
             * Refactored 05 / 16 / 2020
             */

            // Starting by telling the user what we are doing
            Console.WriteLine("We need to get some things from the store!\n\n" +
                "Grocery List: \n\tBanana \n\tBeef Brisket \n\tApple Pie\n\n");

            // Prompting the user for the price of banana
            Console.Write("Let's start with bananas.\nHow much does one cost?: ");
            // Getting user input with validation and converting it to decimal
            decimal bananaCost = Validation.GetDecimal(Console.ReadLine());

            // Prompting the user for the number of bananas to buy
            Console.Write("How many bananas do we need to buy?: ");
            // Getting user input with validation and converting it to decimal
            decimal bananaQuant = Validation.GetDecimal(Console.ReadLine());

            // Calculating total cost of bananas using TotalItemCost function
            decimal totalBananaCost = TotalItemCost(bananaCost, bananaQuant);
            // Outputting total cost of bananas to user
            Console.WriteLine("The total cost for bananas is $" + totalBananaCost + "\n");


            // Promting the user for the price of beef brisket
            Console.Write("Next we need beef brisket.\nHow much does one cost?: ");
            // Getting user input with validation and converting it to decimal
            decimal brisketCost = Validation.GetDecimal(Console.ReadLine());

            // Prompting the user for the number of briskets to buy
            Console.Write("How many briskets do we need to buy?: ");
            // Getting user input with validation and converting it to decimal
            decimal brisketQuant = Validation.GetDecimal(Console.ReadLine());

            // Calulating total cost of briskets using TotalItemCost function
            decimal totalBrisketCost = TotalItemCost(brisketCost, brisketQuant);
            // Outputting total cost of briskets to user
            Console.WriteLine("The total cost for briskets is $" + totalBrisketCost + "\n");




            // Prompting the user for the price of apple pie
            Console.Write("Lastly, we need apple pie.\nHow much does one pie cost?: ");
            // Getting user input with validation and converting it to decimal
            decimal pieCost = Validation.GetDecimal(Console.ReadLine());

            // Prompting the user for the number of apple pies to buy
            Console.Write("How many apple pies do we need to buy?: ");
            // Getting user input with validation and converting it to decimal
            decimal pieQuant = Validation.GetDecimal(Console.ReadLine());

            // Calculating total cost of pies using TotalItemCost function
            decimal totalPieCost = TotalItemCost(pieCost, pieQuant);
            // Outputting total cost of pies to user
            Console.WriteLine("The total cost of pies is $" + totalPieCost + "\n");

            // Calculating subtotal (total before tax)
            decimal subtotal = totalBananaCost + totalBrisketCost + totalPieCost;

            // Calculating tax
            // Prompting the user to enter the sales tax % in their area
            Console.Write("\nWhat is the sales tax in your area? Enter as whole number only (ex. if 6% enter 6): ");
            // Getting user input with validation and converting it to decimal
            decimal taxWholeNumber = Validation.GetDecimal(Console.ReadLine());

            // Getting total tax from CalcTax function
            decimal totalTax = CalcTax(taxWholeNumber, subtotal);
            
            // Calculating grand total
            decimal grandTotal = subtotal + totalTax;

            // Outputting final values to the user (subtotal, tax, and grand total)
            Console.WriteLine("\n\nThe subtotal is $" + subtotal);
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

        // Function for total item costs
        static decimal TotalItemCost(decimal cost, decimal quant)
        {
            // Multiply cost by quantity
            decimal totalItemCost = cost * quant;
            // Return the total cost
            return totalItemCost;
        }

        static decimal CalcTax(decimal percent, decimal subtotal)
        {
            // Getting tax percent from whole number
            decimal taxPercentNumber = percent / 100;
            // Calculating amount of tax based on subtotal
            decimal totalTax = Math.Round(taxPercentNumber * subtotal, 2);

            // Return the total tax based on subtotal amount
            return totalTax;
        }
    }
}
