// Let the user know what we're doing
console.log('Let\'s calculate the price of the books you\'d like to buy.');
// Prompt the user for the number of books they want to buy with validation
let booksToBuy = Number(prompt('Enter the number of books you would like to buy:'));
while(isNaN(booksToBuy) || booksToBuy === ''){
    booksToBuy = Number(prompt('Enter the number of books you would like to buy:'));
}
// Setup variables to use in for loop
let total = 0;
let i;
let booksArray = [];
// For loop to iterate through the number of books to buy to get a price for each
for(i = 0; i < booksToBuy; i++){
    //Prompt the user for the price of each book with validation
    let bookPrice = Number(prompt(`Please enter the price of book ${i +1}`));
    while(isNaN(bookPrice) || bookPrice === ''){
        bookPrice = Number(prompt(`Please enter the price of book ${i + 1}`));
    }
    // Add the book price to the array
    booksArray[i] = bookPrice;
    // Add the book price to the total price
    total += booksArray[i];
    // Output the total price to the user
    console.log(`The total for ${i +1} books is \$${total}`);
}
