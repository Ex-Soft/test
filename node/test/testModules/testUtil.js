let util = require("util");

let obj = {
    a: 10,
    b: 20
};
obj.self = obj;
console.log(util.inspect(obj));
// equ
console.log(obj);

const inspect = Symbol.for('nodejs.util.inspect.custom');

let objWithInspect = {
    a: 10,
    b: 20,
    [inspect]: function() {
        return 123;
    }
};
objWithInspect.self = objWithInspect;
console.log(util.inspect(objWithInspect));

class Password {
    constructor(value) {
        this.value = value;
    }
  
    toString() {
        return 'xxxxxxxx';
    }
  
    [inspect]() {
        return `Password <${this.toString()}>`;
    }
  }
const password = new Password('r0sebud');
console.log(password);

let str = util.format("\"%s\" %d %j", "string", 20, {a:"string", b:20});
console.log(str);
// equ
console.log("\"%s\" %d %j", "string", 20, {a:"string", b:20});

function Animal(name) {
    this.name = name;
}

Animal.prototype.walk = function() {
    console.log(`walk() ${this.name}`);
}

function Rebbit(name) {
    this.name = name;
}

util.inherits(Rebbit, Animal);

Rebbit.prototype.jump = function() {
    console.log(`jump() ${this.name}`);
}

let rebbit = new Rebbit("rebbit");
rebbit.walk();
rebbit.jump();

console.log("Log");
console.info("Log");

console.error("Error");
console.warn("Error");
