const _ = require("lodash");

let obj = { cpp: [{ java: { python: 2012 } }] };

console.log(obj.cpp[0].java.python);

_.set(obj, "cpp[0].java.python", 2020);

console.log(obj.cpp[0].java.python);
