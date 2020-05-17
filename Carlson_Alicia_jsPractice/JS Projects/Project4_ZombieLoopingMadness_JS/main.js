// Number of zombies
let numZombies = 1;
// Number of bites per zombie per day
let numBites = 4;
// Number of days
let days = 8;

// For loop to cycle through each day
for(let i = 1; i <= days; i++){
    // Amount of new zombies created each day(number of bites * number of zombies)
    let newZombies = numZombies * numBites;
    // Update total number of zombies
    numZombies += newZombies;
    // Output the results of how many zombies we have a day
    console.log(`There are ${numZombies} zombies on day #${i}`);
}

// How long will it take to reach a million zombies
// Start on day 1
let numDays = 1;
// Start with 1 zombie
let zombieHordeNumber = 1;
// While loop to loop through days until zombie horde is bigger than 1000000 zombies
while(zombieHordeNumber <= 1000000){
    // New zombies are made based on horde number and how many people each can bite
    let bittenPeople = zombieHordeNumber * numBites;
    // End of day all bitten people will become zombies
    zombieHordeNumber += bittenPeople;
    // Output the results of how many zombies we have a day
    console.log(`On day #${numDays}, there are ${zombieHordeNumber} zombies!`);
    // increase the day number by 1 with each iteration
    numDays++;
}