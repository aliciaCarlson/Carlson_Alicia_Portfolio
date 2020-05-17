using System;

namespace Velasco_Alicia_Arrays
{
    class Program
    {
        static void Main()
        {
            /*Alicia Velasco
             * SDI 1910 Section 01
             * Assignment : Arrays
             * 10 / 13 / 19
             */

            //Problem #1 - Book Buyer

            //Setup variables
            String booksToBuyString;
            int booksToBuy;
            String bookPriceString;
            decimal bookPrices;


            //Tell the user what we're doing and prompt for number of books the user wants to buy
            Console.WriteLine("Let's calculate the price of the books you'd like to buy.\r\n" +
                "Start by entering in the number of books to buy.");

            //Catch user response
            booksToBuyString = Console.ReadLine();

            //validation
            while (!(int.TryParse(booksToBuyString, out booksToBuy)) && booksToBuy > 0)
            {
                //Tell the user the problem
                Console.WriteLine("Please only enter a whole number in number form.");

                //Restate the question
                Console.WriteLine("How many books are you buying?");

                //Recatch the user's response
                booksToBuyString = Console.ReadLine();
            }

            //Declare the array
            decimal[] booksWereBuying = new decimal[booksToBuy];


            //for loop to catch user input - book prices
            for (int i = 0; i < booksWereBuying.Length; i++)
            {
                //Asking the user for the book prices
                Console.WriteLine("Please enter the price of the book you'd like to buy.");
                bookPriceString = Console.ReadLine();


                //Convert and validate book prices
                while (!decimal.TryParse(bookPriceString, out bookPrices))
                {
                    
                    //Tell the user the problem
                    Console.WriteLine("Please enter only numbers");

                    //Restate the question
                    Console.WriteLine("How much is the price of the book?");

                    //Recatch the user's response
                    bookPriceString = Console.ReadLine();

                }

                booksWereBuying[i] = bookPrices;

                //if loop to add the array
                if (i < booksWereBuying.Length)
                {
                    decimal totalPrice = booksWereBuying[i]++;
                    



                    //output results to user
                    Console.WriteLine("The total for {0} books is ${1}", i + 1, totalPrice);

                    //entering blank line
                    Console.WriteLine("");

                }
            }



            /* Problem #1 - Book Buyer Test
             * Test 1:
             *Let's calculate the price of the books you'd like to buy.
                Start by entering in the number of books to buy.
                3
                Please enter the price of the book you'd like to buy.
                5.50
                The total for 1 books is $5.50

                Please enter the price of the book you'd like to buy.
                10.25
                The total for 2 books is $10.25

                Please enter the price of the book you'd like to buy.
                seventy dollars
                Please enter only numbers
                How much is the price of the book?
                17
                The total for 3 books is $17
             *
             *
             * Test 2:
             * Let's calculate the price of the books you'd like to buy.
                Start by entering in the number of books to buy.
                4
                Please enter the price of the book you'd like to buy.
                9.99
                The total for 1 books is $9.99

                Please enter the price of the book you'd like to buy.
                24.34
                The total for 2 books is $24.34

                Please enter the price of the book you'd like to buy.
                12
                The total for 3 books is $12

                Please enter the price of the book you'd like to buy.
                25
                The total for 4 books is $25
             */






            //Problem #2 -

            //Declare and define arrays

            string[] randomThings = new string[5];

            randomThings[0] = "grapes";
            randomThings[1] = "apples";
            randomThings[2] = "limes";
            randomThings[3] = "lemons";
            randomThings[4] = null;

            string[] colors = new string[5];
            colors[0] = "purple";
            colors[1] = "red";
            colors[2] = "green";
            colors[3] = "yellow";
            colors[4] = null;


            //Cycle through the arrays outputting the results
            for (int i = 0; i < randomThings.Length; i++)
            {
                Console.WriteLine("\r\nThe main color of {0} is {1}.", randomThings[i], colors[i]);

            }


            //update array with new values
            randomThings[0] = "ball";
            randomThings[1] = "carrot";
            randomThings[2] = "towel";
            randomThings[3] = "laptop";
            randomThings[4] = "stove";

            colors[0] = "red";
            colors[1] = "orange";
            colors[2] = "white";
            colors[3] = "silver";
            colors[4] = "black";


            //cycle through the arrays outputting the results
            for (int i = 0; i < colors.Length; i++)
            {
                Console.WriteLine("The main color of {0} is {1}.", randomThings[i], colors[i]);

            }

            /*Problem #2 - Coloring Outside the Lines Test
             *
             * Test 1:
             * The main color of grapes is purple.

                The main color of apples is red.

                The main color of limes is green.

                The main color of lemons is yellow.
             *
             *
             * Test 2:
             * The main color of  is .
                The main color of ball is red.
                The main color of carrot is orange.
                The main color of towel is white.
                The main color of laptop is silver.
                The main color of stove is black.
             */




























        }
    }
}
