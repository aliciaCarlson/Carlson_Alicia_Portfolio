// Person class. adventurer uses this class. Has a method for displaying stats and to throw a hand
class Person{
constructor(name) {
    this.name = name;
    this.goldBalance = 500;
    this.health = 500;
}

DisplayStats(){
    console.log(`Adventurer Name - ${this.name}\nHealth - ${this.health}\nGold - ${this.goldBalance}`);
}

ThrowHand(){
    console.log(`\nBattle with a game of Rock | Paper | Scissors`);
    let needAValidAnswer = true;
    let handValue = 0;
    while(needAValidAnswer){
        let handThrown = prompt('What would you like to throw?\n1 - Rock\n2 - Paper\n3 - Scissors\nEnter the number or name of the hand you would like to throw: ');
        switch(handThrown){
            case '1':
            case 'rock':{
                handValue = 1;
                needAValidAnswer = false;
                console.log('You have thrown Rock');
            }
            break;
            case '2':
            case 'paper':{
                handValue = 2;
                needAValidAnswer = false;
                console.log('You have thrown Paper');
            }
            break;
            case '3':
            case 'scissors':{
                handValue = 3;
                needAValidAnswer = false;
                console.log('You have thrown Scissors');
            }
            break;
            default:{
                console.log('Please enter only the number or the name of the hand you would like to throw.');
                needAValidAnswer = true;

            }
            break;
        }
    }
    return handValue;
}
}

// Opponent class. Parent class for NPC, Troll & Giant. Has a method for throwing a RPS hand
class Opponents{
    constructor(name) {
        this.name = name;
    }

    ThrowHand(){
        let handThrown = Math.floor(Math.random() * 3 + 1);
        switch(handThrown){
            case 1:{
                console.log(`${this.name} has thrown Rock.`);
            }
            break;
            case 2:{
                console.log(`${this.name} has thrown Paper.`);
            }
            break;
            case 3:{
                console.log(`${this.name} has thrown Scissors.`);
            }
            break;
        }
        return handThrown;
    }
}

// NPC class. highwayMen and bandits use this class. Unique damage amount. Has method for being able to pay for safe passage
class NPC extends Opponents{
    constructor(name) {
        super(name);
        this.goldBalance = 0;
        this.damage = 15;
    }

    PayForPassage(adventurer){
        console.log(`To avoid a fight with ${this.name} you can pay 50 gold for safe passage through this area!`);
        if(adventurer.goldBalance > 100){
            adventurer.goldBalance -= 50;
            this.goldBalance += 50;
            console.log(`You have paid ${this.name} 50 gold for safe passage through this area.`);
        }else{
            console.log(`You don't have enough gold to pay for safe passage. You must battle in Rock | Paper | Scissors`);
        }
    }

    DoubleForPassage(adventurer){
        console.log(`You should have taken the offer for safe passage when it was first offered!\n${this.name} now has no interest in fighing and is demanding double the gold to safely pass this area.`);
        if(adventurer.goldBalance > 100){
            console.log(`You must now pay ${this.name} double for safe passage.`);
            adventurer.goldBalance -= 100;
            this.goldBalance += 100;
        }else{
            console.log(`You don't have enough gold to pay for safe passage.`);
        }
    }

    TravelersTax(adventurer){
        let payment = prompt('Press enter/return to pay the travelers tax of 50 gold to enter the city:');
        switch(payment){
            case "":{
                adventurer.goldBalance -= 50;
                this.goldBalance += 50;
                console.log(`${adventurer.name}'s gold balance is now ${adventurer.goldBalance} and has been granted entry into the Town of Middle.`);
            }
            break;
            case 'show':{
                console.log(`You show ${this.name} your letter from the king and you are granted entry into the city without paying the traveler's tax.`);
            }
            break;
            default:{
                console.log("Press enter/return to pay the traveler's tax of 50 gold to enter the city");
            }
            break;
        }
    }
}

// Troll class. troll uses this class. Unique damage amount.
class Troll extends Opponents{
    constructor(name) {
        super(name);
      this.damage = 25;
    }
}

// Giant class. giant uses this class. Unique damage amount.
class Giant extends Opponents{
    constructor(name) {
        super(name);
        this.damage = 40;
    }

}

// LocalStorage class. Sets up methods for getting and adding winners to local storage
class LocalStorage{

    static getWinners(){
        let winners;
        if(localStorage.getItem('winners') === null){
            winners = [];
        }else{
            winners = JSON.parse(localStorage.getItem('winners'));
        }
        return winners;
    }

    static addWinner(winner){
        const winners = LocalStorage.getWinners();

        winners.push(winner);

        localStorage.setItem('winners', JSON.stringify(winners));
    }
}

// Instantiating object variables to use in program
let adventurer = null;
let opponent = null;
let highwayMen = new NPC("Highway Men");
let bandits = new NPC("Bandits");
let troll = new Troll("Troll");
let giant = new Giant("Giant");
let travelTax = new NPC("Gate Guard");

// bool and while loop to keep showing menu until user exits. Switch statement to execute correct code depending on user choice
let programRunning = true;
while(programRunning){
    let menu = prompt("M A I N  M E N U\n1 - Create Adventurer\n2 - View Adventurer\n3 - Game Synopsis\n4 - Begin Game\n0 - Exit");
    switch(menu){
        case '1':{
            adventurer = createAdventurer(adventurer);
        }
        break;
        case '2':{
            displayAdventurer(adventurer);
        }
        break;
        case '3':{
            console.log("Journey on a quest to accept the King's invitation of knighthood. Along your quest\n" +
                "you will encounter many foes. Bandits and Highway Men who mean you harm can be paid\n" +
                "off for safe passage. For the more daring adventurer, battle these foes with a game\n" +
                "of Rock, Paper, Scissors. Win and you will be free to pass but lose and your fee for\n" +
                "safe passage will be doubled!");
        }
        break;
        case '4':{
            day1(adventurer);
        }
        break;
        case '0':{
            programRunning = false;
        }
        break;
        default:{
            console.log('Please only enter an option corresponding with the provided menu options.');
        }
        break;
    }
}

// function to create adventurer. Checks for if an adventurer has been created. If adventurer exists, will prompt user if sure what to replace
function createAdventurer(adventurer){
    if(adventurer !== null){
        console.log(`You have already created an adventurer.\nCreating a new adventurer will replace ${adventurer.name}`);
        let needAnswer = true;
        while(needAnswer){
            let answer = prompt('Would you like to create a new adventurer? y/n').toLowerCase();
            switch(answer){
                case 'yes':
                case 'y':{
                    let name = prompt("Enter adventurer's name: ");
                    while(name === ""){
                        name = prompt("Do not leave blank.\nEnter adventurer's name: ");
                    }
                    adventurer = new Person(name);
                    console.log(`Health - ${adventurer.health}`);
                    console.log(`Gold - ${adventurer.goldBalance}`);
                    needAnswer = false;
                }
                break;
                case 'no':
                case 'n':{
                    console.log(`Adventurer remains unchanged.\nAdventurer - ${adventurer.name}\nHealth - ${adventurer.health}\nGold - ${adventurer.goldBalance}`);
                    needAnswer = false;
                }
                break;
                default:{
                    console.log('Please only answer with yes(y) or no(n). Try again..');
                }
            }
        }
    }else{
        let name = prompt("Enter adventurer's name:");
        while(name === ""){
            name = prompt("Do not leave blank. Enter adventurer's name:");
        }
        adventurer = new Person(name);

        console.log(`Adventurer - ${adventurer.name}\nHealth - ${adventurer.health}\nGold - ${adventurer.goldBalance}`)
    }

    return adventurer;
}

// function to display the adventurer. checks for if an adventurer has been created
function displayAdventurer(adventurer){
    if(adventurer !== null){
        adventurer.DisplayStats();
    }
    else{
        console.log('An adventurer has not yet been created.\nTry creating an adventurer to view their information.');
    }
}

// function for when an opponent is encountered. if payable, given the option to pay.
function encounterOpponent(opponent){
    let winnerCode = 0;
    let gamesPlayed = 0;
    if(opponent === highwayMen || opponent === bandits){
        let answer = prompt("Would you like to\n1 - Pay for safe passage\n2 - Battle with Rock | Paper | Scissors\nEnter your choice:");
        switch(answer){
            case '1':
            case 'pay':{
                opponent.PayForPassage(adventurer);
            }
            break;
            case '2':
            case 'battle':{
                winnerCode = battle(opponent);
                if(winnerCode !== 1){
                    opponent.DoubleForPassage(adventurer);
                }
            }
            break;
        }
    }else{
        while(winnerCode !== 1 && gamesPlayed < 3){
            winnerCode = battle(opponent);
            gamesPlayed += 1;
        }
        if(gamesPlayed === 3){
            console.log(`You have weakened the ${opponent.name} enough to defeat it!`);
        }
    }
}

// function to calculate the winner based upon adventurer hand played and opponent hand throw
function battle(opponent){
    let winnerCode = 0;
    let adventurerHand = adventurer.ThrowHand();
    let opponentHand = opponent.ThrowHand();

    switch(adventurerHand){
        case 1:{
            switch(opponentHand){
                case 1:{
                    console.log("It's a tie!");
                    winnerCode = 3;
                }
                break;
                case 2:{
                    console.log(`${opponent.name} has won!`);
                    winnerCode = 2;
                    adventurer.health -= opponent.damage;
                }
                break;
                case 3:{
                    console.log(`${adventurer.name} has won!`);
                    winnerCode = 1;
                }
                break;
            }
        }
        break;
        case 2:{
            switch(opponentHand){
                case 1:{
                    console.log(`${adventurer.name} has won!`);
                    winnerCode = 1;
                }
                break;
                case 2:{
                    console.log("It's a tie!");
                    winnerCode = 3;
                }
                break;
                case 3:{
                    console.log(`${opponent.name} has won!`);
                    winnerCode = 2;
                    adventurer.health -= opponent.damage;
                }
                break;
            }
        }
        break;
        case 3:{
            switch(opponentHand){
                case 1:{
                    console.log(`${opponent.name} has won!`);
                    winnerCode = 2;
                    adventurer.health -= opponent.damage;
                }
                break;
                case 2:{
                    console.log(`${adventurer.name} has won!`);
                    winnerCode = 1;
                }
                break;
                case 3:{
                    console.log("It's a tie!");
                    winnerCode = 3;
                }
                break;
            }
        }
        break;
    }
    console.log();
    return winnerCode;
}

// function to display if adventurer don't have enough health or gold to continue
function gameOver(){
    console.log("You don't have enough health or gold to continue on your journey.\nCreate a new adventurer and try again!");
    adventurer = null;
}

// functions for each day. Displays story. calls encounterOpponent. Checks if user has enough health and gold to continue to next day. calls next day or gameOver accordingly
function day1(adventurer){
    alert(`Adventurer ${adventurer.name},\n` +
    `   My daughter, Princess Katia, has told me of your great feats. Your many ` +
        `victories over the fearsome creatures of our land. I'm calling on you now. ` +
        `Journey from The Wooded Valley to my palace in The Town of Middle to accept my offer ` +
        `of knighthood and the many rewards that come along with it.\n` +
        `Be warned! You will face many creatures and unsavory persons on your journey. ` +
        `Make it past all of your adversaries and arrive at the castle to claim your rightful title of knight.\n` +
        `       Good Luck\n` +
        `           King Modzog`)
    console.log(`D A Y  1\n` +
    `You embark on your journey. The terrain is mild. You don't encounter\n` +
    `any foes. You end the day with ${adventurer.health} Health & ${adventurer.goldBalance} Gold.`);
    alert("Read the story in the console.\nPress ok when you are ready to continue to the next day.");

    day2(adventurer);
}

function day2(adventurer){
    opponent = highwayMen;
    console.log(`D A Y  2\n` +
    `You awake at sunrise and set out. Mid-day you are met by ${opponent.name}. You can choose to\n` +
    `pay or fight.\n`);
    encounterOpponent(opponent);
    if(adventurer.health > 40 && adventurer.goldBalance > 50){
        console.log(`At dusk you make camp. You end the day with ${adventurer.health} Health & ${adventurer.goldBalance} Gold.`);
        alert("Read the story in the console.\nPress ok when you are ready to continue to the next day.");
        day3(adventurer);
    }
    else{
        gameOver();
    }
}

function day3(adventurer){
    opponent = troll;
    console.log(`D A Y  3\n` +
    `You awake to an unknown sound! There's a ${opponent.name} in your camp! You must fight him off...\n`);
    encounterOpponent(opponent);
    if(adventurer.health > 40 && adventurer.goldBalance > 50){
        console.log(`You continue on your journey without further encounters today. You end the day with ${adventurer.health} Health & ${adventurer.goldBalance} Gold.`);
        alert("Read the story in the console.\nPress ok when you are ready to continue to the next day.");

        day4(adventurer);
    }
    else{
        gameOver();
    }
}

function day4(adventurer){
    opponent = giant;
    console.log(`D A Y  4\n` +
    `You awake at dawn and set out. You take a mountain pass. You've saved yourself 2 days of traveling\n` +
    `but have to pass through a ${opponent.name}'s camp. You must fight the ${opponent.name}...\n`);
    encounterOpponent(opponent);
    if(adventurer.health > 40 && adventurer.goldBalance > 50){
        console.log(`You continue on your journey and make camp in a mountain cave.\n` +
            `You end the day with ${adventurer.health} Health & ${adventurer.goldBalance} Gold.`);
        alert("Read the story in the console.\nPress ok when you are ready to continue to the next day.");
        day5(adventurer);
    }
    else{
        gameOver();
    }
}

function day5(adventurer){
    opponent = bandits;
    console.log(`D A Y  5\n` +
    `You awaken mid-morning and continue on your quest. By mid-afternoon you begin to see the outline of the castle\n` +
    `on the horizon. At dusk you are approached by ${opponent.name}. You can pay or fight...\n`);
    encounterOpponent(opponent);
    if(adventurer.health > 40 && adventurer.goldBalance > 50){
        console.log(`\nYou continue a few miles and make camp. You will reach your destination tomorrow!\n` +
            `You end the day with ${adventurer.health} Health & ${adventurer.goldBalance} Gold.`);
        alert("Read the story in the console.\nPress ok when you are ready to continue to the next day.");
        day6(adventurer);
    }
    else{
        gameOver();
    }
}

function day6(adventurer){
    opponent = travelTax;
    console.log("You awaken before sunrise eager to arrive at the castle. You set off while it's still dark. The land around the\n" +
    "Town of Middle is well patrolled by the town guards. Mid-day you arrive at the town gates.\n" +
    "There is a travelers tax and you must pay 50 gold to enter the city.");
    opponent.TravelersTax(adventurer);
    console.log(`You enter the city with ${adventurer.health} Health & ${adventurer.goldBalance} Gold`);

    console.log(`You've arrived at the castle. You enter the King's Throne Room where he congratulates you.\n` +
    `You are knighted and presented with an official decree!`)
    alert(`Adventurer - ${adventurer.name}\n` +
    `Ending Health - ${adventurer.health}\n` +
    `Ending Gold - ${adventurer.goldBalance}\n` +
    `This decree is to certify that Adventurer ${adventurer.name} is now Knight ${adventurer.name} by official order of King Modzog!\n\n` +
    `You can go back and view you ending stats in local storage!`);

    // Adds winner to localStorage
    LocalStorage.addWinner(adventurer);
}

