using System;

namespace Velasco_Alicia_Conditionals
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Alicia Velasco
             * SDI 1910 Section 01
             * Assignment: Code Exercise: Conditionals
             * 10 / 13 /19 
             */

            //Problem #1 - Free Shipping
            //Tell the user what we are doing.
            Console.WriteLine("Please enter how many items you purchased to calculate your shipping cost.");

            //Catch the user's response
            string itemsBoughtString = Console.ReadLine();

            //Converting the string to number datatype
            decimal numItemsBought = decimal.Parse(itemsBoughtString);

            //Create variable for shipping cost per item
            decimal perItemShipping = 1.25m;


            //Using if for user purchases with less than 5 items
            if (numItemsBought < 5)
            {
                //calculating total shipping cost
                decimal totalShippingCost = numItemsBought * perItemShipping;

                //Tell the user what their shipping total is
                Console.WriteLine("Your cost for shipping today for {0} items is ${1}.", numItemsBought, totalShippingCost);

            }
            //Using else for if the user buys 5 or more items
            else
            {
                //Tell the user that their shipping free!
                Console.WriteLine("Congratulations, you have bought {0} items and qualify for free shipping!", numItemsBought);

            }

            /*Problem 1 - Free Shipping Test
             * Items: 2 - Results: Your cost for shipping today for 2 items is $2.50.
             * Items: 4 - Results: Your cost for shipping today for 4 items is $5.00.
             * Items: 5 - Results: Congratulations, you have bought 5 items and qualify for free shipping!
             * Items: 7 - Results: Congratulations, you have bought 7 items and qualify for free shipping!
             * Items: 0 - Results: Your cost for shipping today for 0 items is $0.00.
             * Items: 145 - Results: Congratulations, you have bought 145 items and qualify for free shipping!
             */

            //Problem #2 - Mall Employee Discount

            //Tell the user what we are doing
            Console.WriteLine("\r\nPlease enter the cost of the items you're buying and if you're a mall employee to calulate your total price.");

            //Ask for the cost of the first item
            Console.WriteLine("How much is your first item?");
            //Catch the users response
            string firstItemString = Console.ReadLine();
            //Setup number variable to catch the converted value
            decimal firstItem;
            //Validation
            while (!(decimal.TryParse (firstItemString, out firstItem)))
            {
                //Tell the user the problem
                Console.WriteLine("\r\nPlease only enter the price of the item in number form.");
                //Restate the question
                Console.WriteLine("How much is your first item?");
                //Recatch the users response
                firstItemString = Console.ReadLine();

            }


            //Ask for the cost of the second item
            Console.WriteLine("How much is your second item?");
            //Catch the users response
            string secondItemString = Console.ReadLine();
            //Setup number variable to catch the converted value
            decimal secondItem;
            //Validation
            while (!(decimal.TryParse(secondItemString, out secondItem)))
            {
                //Tell the user the problem
                Console.WriteLine("\r\nPlease only enter the price of the item in number form.");
                //Restate the question
                Console.WriteLine("How much is your second item?");
                //Recatch the users response
                secondItemString = Console.ReadLine();

            }

            //Adding first and second item to get total item price
            decimal totalItemPrice = firstItem + secondItem;


            //Asking the user if they work at the mall
            Console.WriteLine("Are you a mall employee?");
            //catch the users response
            string employeeAnswerString = Console.ReadLine();
            //validation
            while (employeeAnswerString.ToLower() != "yes" && employeeAnswerString.ToLower() != "no") 
            {
                //Tell the user the problem
                Console.WriteLine("\r\nPlease only enter yes or no.");
                //Reask the question
                Console.WriteLine("Are you a mall empolyee?");
                //Recatch the response
                employeeAnswerString = Console.ReadLine();
            }

            //Creating mall employee discount variable and equation for total price
            decimal discount = 10;
            decimal discountPercent = discount / 100;
            decimal employeeDiscount = discountPercent * totalItemPrice;
            decimal employeeTotal = totalItemPrice - employeeDiscount;

            //creating if variable to apply employee discount or not
            if (employeeAnswerString.ToLower() == "yes")
            {
                //Telling the user (mall employee) their purchase price and price after discount
                Console.WriteLine("Your total purchase is ${0}, but with your 10% employee discount it is now ${1}.", totalItemPrice, employeeTotal);
            }
            else
            {
                //Telling the user their purchase price
                Console.WriteLine("Your total purchase is ${0}", totalItemPrice);
            }

            /*Problem #2 - Mall Employee Discount Test
             * 1st item : $65.90 - 2nd item : $85.00 - "yes" - Results : Your total purchase is $150.90, but with your 10% employee discount it is now $135.810.
             * 1st item : $19.99 - 2nd item : $40.20 - "no" - Results : Your total purchase is $60.19
             * 1st item : $104.78 - 2nd item : $97.84 - "yes" - Results : Your total purchase is $202.62, but with your 10% employee discount it is now $182.358.
             */


            //Problem #3 - Apple Pickers

            //Tell the user what we're doing and ask them how many pounds of apples they picked
            Console.WriteLine("\r\nHow many pounds of apples are in your basket?");

            //Catch the users response
            string basketWeightString = Console.ReadLine();

            //set up number variable to catch the converted value
            decimal basketWeight;
            while (!(decimal.TryParse(basketWeightString, out basketWeight)))
            {
                //Tell the user the problem
                Console.WriteLine("\r\nPlease only enter your basket weight in number form.");
                //Reask the problem
                Console.WriteLine("How many pounds of apples are in your basket?");
                //Recatch the response
                basketWeightString = Console.ReadLine();
             }
            //Create if variable to test each weight to calculate cost per pound and total cost based on different weight groups
            if (basketWeight < 7)
            {
                //Set up cost per pound variable
                decimal u7CostPerPound = 1;
                //calculate total price variable
                decimal u7TotalPrice = basketWeight * u7CostPerPound;
                //Output total price to the user
                Console.WriteLine("Your basket of apples of {0}lbs. costs ${1}.", basketWeight, u7TotalPrice);
            }
            else if (basketWeight < 15.25m)
            {
                //Set up cost per pound variable
                decimal u15CostPerPound = .90m;
                //calculate total price variable
                decimal u15TotalPrice = basketWeight * u15CostPerPound;
                //Output total price to the user
                Console.WriteLine("Your basket of apples of {0}lbs. costs ${1}.", basketWeight, u15TotalPrice);
            }
            else if (basketWeight < 40)
            {
                //Set up cost per pound variable
                decimal u40CostPerPound = .80m;
                //calculate total price variable
                decimal u40TotalPrice = basketWeight * u40CostPerPound;
                //Output total price to the user
                Console.WriteLine("Your basket of apples of {0}lbs. costs ${1}.", basketWeight, u40TotalPrice);
            }


            else if (basketWeight < 70.5m)
            {
                //Set up cost per pound variable
                decimal u70CostPerPound = .70m;
                //calculate total price variable
                decimal u70TotalPrice = basketWeight * u70CostPerPound;
                //Output total price to the user
                Console.WriteLine("Your basket of apples of {0}lbs. costs ${1}.", basketWeight, u70TotalPrice);

            }
            else if (basketWeight <= 100)
            {
                //Set up cost per pound variable
                decimal oneHundredCostPerPound = .60m;
                //calculate total price variable
                decimal oneHundredTotalPrice = basketWeight * oneHundredCostPerPound;
                //Output total price to the user
                Console.WriteLine("Your basket of apples of {0}lbs. costs ${1}.", basketWeight, oneHundredTotalPrice);   
            }
            else
            {
                //Set up cost per pound variable
                decimal aboveOneHundredPerPound = .50m;
                //calculate total price variable
                decimal aboveOneHundredTotalPrice = basketWeight * aboveOneHundredPerPound;
                //Output total price to the user
                Console.WriteLine("Your basket of apples of {0}lbs. costs ${1}.", basketWeight, aboveOneHundredTotalPrice);
            }

            /* Problem #3 - Apple Pickers Tests
             * Apple Weight : 4.5lbs - Results : Your basket of apples of 4.5lbs. costs $4.5.
             * Apple Weight : 10 lbs - Results : Your basket of apples of 10lbs. costs $9.00.
             * Apple Weight : 15.25 lbs - Results : Your basket of apples of 15.25lbs. costs $12.2000.
             * Apple Weight : 30 lbs - Results : Your basket of apples of 30lbs. costs $24.00.
             * Apple Weight : 60.50 lbs - Results : Your basket of apples of 60.50lbs. costs $42.3500.
             * Apple Weight : 100 lbs - Results : Your basket of apples of 100lbs. costs $60.00.
             * Apple Weight : 150.30 lbs - Results : Your basket of apples of 150.30lbs. costs $75.1500.
             * Apple Weight : 598 lbs - Results : Your basket of apples of 598lbs. costs $299.00.
             */


            //Problem #4 - Logical Operators
            //Tell the user what we're doing and ask for their age
            Console.WriteLine("\r\nPlease enter you age to calculate your ticket price for Comic Con");

            //Catch the user's response
            string ageString = Console.ReadLine();

            //Set up number variable to catch the converted value
            int age;

            while (!(int.TryParse(ageString, out age)))
            {
                //Tell the user the problem
                Console.WriteLine("\r\nPlease only enter your age in number form.");

                //Reask the question
                Console.WriteLine("Please enter your age to calculate your ticket price for Comic Con.");
                //Recatch the response
                ageString = Console.ReadLine();
            }
            //Create if variable to test ages entered to determine which line to run
            if (age < 7 || age >= 65)
            {
                //Outout to the user when age is less than 7 or greater than or equal to 65
                Console.WriteLine("Your cost for your ticket to Comic Con is $40.00.");
            }
            else
            {
                //Output to user when age fall between 7-64
                Console.WriteLine("Your cost for your ticket to Comic Con is $55.00.");
            }

            /* Problem #4 - Nerd Out Tests
             * Age : 68 - Results : Your cost for your ticket to Comic Con is $40.00.
             * Age : 29 - Results : Your cost for your ticket to Comic Con is $55.00.
             * Age : 6 - Results : Your cost for your ticket to Comic Con is $40.00.
             * Age : 7 - Results : Your cost for your ticket to Comic Con is $55.00.
             * Age : 24 - Results : Your cost for your ticket to Comic Con is $55.00.
             */

        }




    }
}
