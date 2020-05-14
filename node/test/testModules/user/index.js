//module.exports = exports = this

let db = require("db");
let log = require("../logger")(module);

class User {
    constructor(name) {
        this._name = name;
    }

    get name() {
        return this._name;
    }

    set name(value) {
        this._name = value;
    }

    hello(who) {
        log(`${db.getPhrase("Hello")}, \"${who.name}\"!`);
    }
}

console.log("user.js is required!");

//this.User = User;
// equ
//exports.User = User;
// equ
//module.exports.User = User;

//exports = User; // doesn't work because "exports" is a reference to "module.exports"
module.exports = User;

//console.log(module);