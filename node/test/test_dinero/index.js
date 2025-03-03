//import { dinero } from 'dinero.js';
//import { USD } from '@dinero.js/currencies';

const { dinero, add, multiply, toDecimal } = require('dinero.js');
const { USD } = require('@dinero.js/currencies');

const roundCurrency = value => !isNaN(value) ? Math.round((value + Number.EPSILON) * 100) / 100 : 0.0;

console.log(parseFloat("258.5300"), parseFloat("258.5300") * 100); // 258.53 25852.999999999996

let balance

try {
    balance = dinero({ amount: parseFloat("258.5300") * 100, currency: USD });
    console.log(balance.toDecimal());
} catch (e) {
    console.log(e);
}

balance = dinero({ amount: roundCurrency(parseFloat("258.5300") * 100), currency: USD });
console.log(toDecimal(balance));

const price = dinero({ amount: 50.09 * 100, currency: USD });
console.log(toDecimal(price));

const items = [
    { quantity: 1, price: "155.17" },
    { quantity: 1, price: "80.17" }
];

let totalPure = 0.0;
items.forEach((item) => {
    totalPure += item.quantity * parseFloat(item.price);
});
console.log("%o %o", totalPure, totalPure.toFixed(2)); // 235.33999999999997 235.34

totalPure = items.reduce((accumulator, currentValue) => accumulator + currentValue.quantity * parseFloat(currentValue.price), 0.0);
console.log("%o %o", totalPure, totalPure.toFixed(2)); // 235.33999999999997 235.34

let totalDinero  = dinero({ amount: 0, currency: USD });
items.forEach((item) => {
    totalDinero = add(totalDinero, multiply(dinero({ amount: parseFloat(item.price.replace(/\D/g, "")), currency: USD }), item.quantity));
});
console.log(toDecimal(totalDinero)); // 235.34

totalDinero = items.reduce((accumulator, currentValue) => add(accumulator, multiply(dinero({ amount: parseFloat(currentValue.price.replace(/\D/g, "")), currency: USD }), currentValue.quantity)), dinero({ amount: 0, currency: USD }));
console.log(toDecimal(totalDinero)); // 235.34