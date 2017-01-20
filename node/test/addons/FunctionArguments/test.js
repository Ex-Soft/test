// test.js
const addon = require('./build/Release/addon');

console.log('This should be eight:', addon.add(3, 5));
console.log(addon.methodWOReturn());
console.log(addon.methodWNullReturn());
