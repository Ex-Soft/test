const moment = require("moment");
require("moment-round");

function isDate(value) {
    return value && (value instanceof Date || toString.call(value) === "[object Date]") && value.toString() !== "Invalid Date";
}
  
function isString(value) {
    return typeof value === 'string';
}
  
function getOADate(value, roundToDate) {
    let result;

    if (isString(value) && !!value) {
        result = new Date(value);
    } else if (isDate(value)) {
        result = value;
    }

    if (!isDate(result)) {
        return undefined;
    }

    if (roundToDate) {
       const roundedDate = moment(result).round(1, 'hours');

        if (roundedDate.hour()) {
            console.log(roundedDate.hour());
        }

       result = (roundedDate.hour() ? roundedDate.hour(0) : roundedDate).toDate();
    }

    return result;
}

let m1, m2, precision, key, str;

precision = 15;
key = "seconds";
m1 = moment("2023-02-22T00:00:13+02:00");
m2 = m1.round(precision, key);
console.log(m2.toDate(), precision, key);

precision = 1;
key = "hours";
//str = "2023-01-19T23:59:56+02:00";
str = "2023-01-19T23:59:56.000Z";
m1 = moment(str);
console.log(m1.toDate());
m2 = m1.round(precision, key);
console.log(m2.toDate(), precision, key, m2.isDST());
console.log(getOADate(str, true));

//str = "2023-04-09T00:59:56+03:00";
str = "2023-04-09T00:59:56.000Z";
m1 = moment(str);
console.log(m1.toDate());
m2 = m1.round(precision, key);
console.log(m2.toDate(), precision, key, m2.isDST());
console.log(getOADate(str, true));

str = "2024-02-29T23:59:59.123Z";
m1 = moment(str);
console.log(m1.toDate());
m2 = m1.round(precision, key);
console.log(m2.toDate(), precision, key, m2.isDST());
console.log(getOADate(str, true));

//str = "2023-04-09T00:59:56.123Z";
str = "2023-04-09T23:59:59.123Z";
m1 = moment(str);
console.log(m1.toDate());
m2 = m1.round(precision, key);
console.log(m2.toDate(), precision, key, m2.isDST());
console.log(getOADate(str, true));