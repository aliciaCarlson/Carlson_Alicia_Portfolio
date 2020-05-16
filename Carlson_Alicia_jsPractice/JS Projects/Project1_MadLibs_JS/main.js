// Welcome the user to the program - print to the console
console.log('Welcome to my MadLibs!');

// Prompt the user for their name & validate that a name was entered
let name = prompt('Please enter your name to begin:');
while(name === ''){
    name = prompt('Please enter your name to begin:');
}
// Print a personalized greeting to the console
console.log(`Welcome ${name}!`);
// Instructions for what to enter.
console.log('Please answer the following questions with the first word that comes to mind.\nAt the end you\'ll have a unique complete story!');

// Prompt the user for an animal & validate that something was entered
let animal = prompt('Enter an animal:');
while(animal === ''){
    animal = prompt('Enter an animal');
}

// Prompt the user for a character name & validate that something was entered
let charName = prompt('Enter a name:');
while(charName === ''){
    charName = prompt('Enter a name:');
}

// Prompt the user for an adjective & validate that something was entered
let adjective = prompt('Enter an adjective:');
while(adjective === ''){
    adjective = prompt('Enter an adjective:');
}

// Prompt the user for a food & validate that something was entered
let food = prompt('Enter something that you\'d eat:');
while(food === ''){
    food = prompt('Enter something that you\'d eat:');
}

// Prompt the user for a year & validate that a number was entered
let year = Number(prompt('Enter a year:'));
while(isNaN(year) || year === ''){
    year = Number(prompt('In number form, Enter a year:'));
}

// Prompt the user for a cost & validate that a number was entered
let cost = Number(prompt('Enter a cost:'));
while(isNaN(cost) || cost === ''){
    cost = Number(prompt('In number form, Enter a cost:'));
}

// Prompt the user for a number & validate that a number was entered
let quantity = Number(prompt('Enter a number:'));
while(isNaN(quantity) || quantity === ''){
    quantity = Number(prompt('In number form, Enter a number:'))
}

// Print the story with user input to the console
console.log(`Long ago, in the year ${year}, there lived a(n) ${animal} named ${charName}.\n` +
`${charName} the ${animal} was unhappy because he was ${adjective}.\n` +
`In ${year} it was frowned upon to be ${adjective}.\n` +
`One day, ${charName} met a wizard.\n` +
`The wizard told ${charName} that he could buy ${quantity} magical ${food}(s) for \$${cost}.\n` +
`to help him not be ${adjective}! This offer was too good to pass up!\n` +
`${charName} the ${animal} bought the ${food}(s) and ate them.\n` +
`Instantly, he was no longer ${adjective} and lived happily ever after!`);