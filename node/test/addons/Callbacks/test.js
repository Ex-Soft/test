// test.js
const addon = require('./build/Release/addon');

addon((msg) => {
  console.log(msg); // 'hello world'
});

function test(msg) {
  console.log(msg);
  console.log(arguments)
}

addon(test);