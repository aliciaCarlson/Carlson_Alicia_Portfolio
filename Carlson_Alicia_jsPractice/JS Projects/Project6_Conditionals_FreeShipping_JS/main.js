// Prompt the user for number of items that they bought
let itemsBought = Number(prompt('To calculate shipping cost, enter the number of items you purchased:'));

// Variable to hold shipping cost
let perItemShipping = 1.25;

// If statement to calculate shipping
if(itemsBought < 5){
    let totalShippingCost = itemsBought * perItemShipping;
    console.log(`Your cost for shipping today for ${itemsBought} items is \$${totalShippingCost}`);
}
else{
    console.log(`Congratulations, you have bought ${itemsBought} items and qualify for free shipping!`);
}