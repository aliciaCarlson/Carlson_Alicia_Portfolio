// Let the user know what we're doing
console.log('Hey there! We need to order shirts for ouw bowling team and need to know how many of each size we are going to need.');
console.log('This program will tell you exactly how much to order!');

// Declare first array
let shirtOrder = ["Medium", "Small", "X-Large", "Small", "Large", "Medium", "Small", "X-Large", "XX-Large"];
// Declare second array
//let shirtOrder = ["XX-Large", "Medium", "Large", "Small", "X-Large", "Small", "Large", "XX-Large", "Large", "XX-Large", "Medium", "Medium"];

// Setup variables to hold number of each size
let small = 0;
let medium = 0;
let large = 0;
let xLarge = 0;
let xxLarge = 0;

//Create for loop to cycle through arrays
for(let i = 0; i < shirtOrder.length; i++){
    // Conditionals to check for size of shirt and add 1 to correct size
    if(shirtOrder[i] === "Small"){
        small += 1;
    }
    else if(shirtOrder[i] === "Medium"){
        medium += 1;
    }
    else if(shirtOrder[i] === "Large"){
        large += 1;
    }
    else if(shirtOrder[i] === "X-Large"){
        xLarge += 1;
    }
    else if(shirtOrder[i] === "XX-Large"){
        xxLarge += 1;
    }
}

// Output the results to the user
console.log(`Order ${small} Small Shirt(s)\nOrder ${medium} Medium Shirt(s)\nOrder ${large} Large Shirt(s)\nOrder ${xLarge} X-Large Shirt(s)\nOrder ${xxLarge} XX-Large Shirt(s)`);