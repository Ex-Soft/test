// test.js
const addon = require('./build/Release/addon');

var obj = new addon.MyObject(10);
console.log(addon.MyObject.prototype);
console.log(obj.plusOne()); // 11
console.log(obj.plusOne()); // 12
console.log(obj.plusOne()); // 13

console.log(addon.BaseObjectWrap.prototype);

var baseObj = new addon.BaseObjectWrap(100, 200);
console.log(baseObj.height());
console.log(baseObj.width());
console.log(baseObj.ping());
console.log(baseObj.pong());