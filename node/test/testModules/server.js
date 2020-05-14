let log = require("./logger")(module);
let db = require("db");
db.connect();

let User = require("./user");
console.log(typeof(User));

function run() {
    let
        first = new User("1st"),
        second = new User("2nd");

    first.hello(second);

    log(db.getPhrase("Run successful"));
}

if (module.parent) {
    exports.run = run;
} else {
    run();
}

require("./testGlobal");
console.log(globalVar1);
