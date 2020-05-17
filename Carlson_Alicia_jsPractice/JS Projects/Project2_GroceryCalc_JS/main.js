// alert & console output to let the user know what we're doing
alert('It\'s time to party!! We have to go shopping!\nGrocery List:\n\tBanana(s)\n\tBeef Brisket(s)\n\tApple Pie(s)');
//console.log('Grocery List:\n\tBanana(s)\n\tBeef Brisket(s)\n\tApple Pie(s)');



// Function to get total cost of grocery items
let totalItemCost = function(cost, quant){ return cost * quant }

// Prompt for cost of a banana with validation
let bananaCost = Number(prompt('How much does one banana cost?'));
while(isNaN(bananaCost) || bananaCost === ''){
    bananaCost = Number(prompt('How much does one banana cost?'));
}
// Prompt for quantity of bananas needed with validation
let bananaQuant = Number(prompt('How many bananas do we need?'));
while(isNaN(bananaQuant) || bananaQuant === ''){
    bananaQuant = Number(prompt('How many bananas do we need?'));
}
// Call to totalItemCost function to get total cost of bananas
let totalBananaCost = Number(totalItemCost(bananaCost, bananaQuant).toFixed(2));
// Output the total cost of the banana(s) to the user
console.log(`The total cost for ${bananaQuant} banana(s) is \$${totalBananaCost}`);

// Prompt for cost of a beef brisket with validation
let brisketCost = Number(prompt('How much does one beef brisket cost?'));
while(isNaN(brisketCost) || brisketCost === ''){
    brisketCost = Number(prompt('How much does one beef brisket cost?'));
}
// Prompt for quantity of beef briskets needed with validation
let brisketQuant = Number(prompt('How many beef briskets do we need?'));
while(isNaN(brisketQuant) || brisketQuant === ''){
    brisketQuant = Number(prompt('How many beef briskets do we need?'));
}
// Call to totalItemCount function to get total cost of beef briskets
let totalBrisketCost = Number(totalItemCost(brisketCost, brisketQuant).toFixed(2));
// Output the total cost of the brisket(s) to the user
console.log(`The total cost for ${brisketQuant} beef brisket(s) is \$${totalBrisketCost}`);

// Prompt for cost of an apple pie with validation
let pieCost = Number(prompt('How much does one apple pie cost?'));
while(isNaN(pieCost) || pieCost === ''){
    pieCost = Number(prompt('How much does one apple pie cost?'));
}
// Prompt for quantity of apple pies needed with validation
let pieQuant = Number(prompt('How many apple pies do we need?'));
while(isNaN(pieQuant) || pieQuant === ''){
    pieQuant = Number(prompt('How many apple pies do we need?'));
}
// Call to totalItemCount function to get total cost of apple pie(s)
let totalPieCost = Number(totalItemCost(pieCost, pieQuant).toFixed(2));
// Output the total cost of the apple pie(s) to the user
console.log(`The total cost for ${pieQuant} apple pie(s) is \$${totalPieCost}`);

// Prompt for sales tax percentage in user area with validation
let taxWholeNumber = Number(prompt('What is the sales tax in your area? Enter as a whole number.\n(ex. if sales tax is 6% enter 6)'));
while(isNaN(taxWholeNumber) || taxWholeNumber === ''){
    taxWholeNumber = Number(prompt('What is the sales tax in your area? Enter as a whole number.\n(ex. if sales tax is 6% enter 6)'));
}

// Variable to add and hold subtotal
let subtotal = totalBananaCost + totalBrisketCost + totalPieCost;

// Function to find total sales tax based on subtotal
function calcSalesTax(taxWholeNumber, subtotal){
    let taxPercent = taxWholeNumber / 100;
    let totalTax = (taxPercent * subtotal).toFixed(2);
    return Number(totalTax);
}
// Variable to hold returned value form salesTax function
let salesTax = calcSalesTax(taxWholeNumber, subtotal);
// Variable to hold grand total
let grandTotal = (subtotal + salesTax).toFixed(2);
// Output subtotal, tax and grand total to the console
console.log(`\tSubtotal     \$${subtotal.toFixed(2)}\n\tSales Tax    \$${salesTax}\n\tGrand Total  \$${grandTotal}`);