class Animal{
    constructor(type, name, treat) {
        this._type = type;
        this._name = name;
        this.treat = treat;
    }

    feedTreat(howMany) {
        return `You have fed ${this._name} the ${this._type} ${howMany} ${this.treat} treat(s)!`;
    }

    makeNoise(){
        return `${this._name} the ${this._type} made a noise`;
    }

}

let millie = new Animal('monkey', 'millie', 'banana');
console.log(millie);
console.log(millie.feedTreat(1));
console.log(millie.makeNoise());

class Dog extends Animal{
    constructor(type, name, treat, size, weight) {
        super(type, name, treat);

        this.size = size;
        this.weight = weight;
    }

    calculateNumOfTreats(){
        let numTreats;
        switch(this.size){
            case 'xsmall':{
                numTreats = .5;
            }
            break;
            case 'small':{
                numTreats = 1;
            }
            break;
            case 'medium':{
                numTreats = 2;
            }
            break;
            case 'large' :{
                numTreats = 3;
            }
            break;
            case 'xlarge':{
                numTreats = 4;
            }
            break;
        }
        return this.feedTreat(numTreats);
    }

    makeNoise() {
        return `${this._name} the ${this._type} barked!`;
    }

}

let mozzie = new Dog('Great Dane', 'Mozzie', 'milkbone', 'xlarge', 120);
console.log(mozzie);
console.log(mozzie.calculateNumOfTreats());
console.log(mozzie.makeNoise());
// Fun fact - Mozzie is my doggie (: