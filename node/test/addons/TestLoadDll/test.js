// test.js
const addon = require('./build/Release/addon');

var baseObj = new addon.BaseObjectWrap();
console.log(baseObj.sayHello());