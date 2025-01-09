const moment = require("moment");
require("moment-round");

function isDate(value) {
  return (
    value &&
    (value instanceof Date || toString.call(value) === "[object Date]") &&
    value.toString() !== "Invalid Date"
  );
}

function isString(value) {
  return typeof value === "string";
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
    const roundedDate = moment(result).round(1, "hours");

    if (roundedDate.hour()) {
      console.log(roundedDate.hour());
    }

    result = (roundedDate.hour() ? roundedDate.hour(0) : roundedDate).toDate();
  }

  return result;
}

let m1, m2, precision, key, str, d1;

m1 = moment.utc("2024-12-23T02:00:00.000+02:00");
m2 = moment.utc("2024-12-24T02:00:00.000+02:00");
key = m1.diff(m2, "days", true); // -1
key = m2.diff(m1, "days", true); // 1
m2 = moment.utc("2024-12-23T14:00:00.000+02:00");
key = m1.diff(m2, "days", true); // -1
key = m2.diff(m1, "days", true); // 1

m1 = moment.utc(new Date()).startOf("day").add({ years: 1 });
d1 = m1.toDate();
m2 = m1.add({ days: -3 });
d1 = m2.toDate();

str = "2024-10-01T00:00:00.000-08:00";
m1 = moment.utc(new Date(str)); // Tue Oct 01 2024 08:00:00 GMT+0000
d1 = m1.toDate(); // Tue Oct 01 2024 11:00:00 GMT+0300 (Eastern European Summer Time)
console.log(m1.toString(), d1.toString());
m1 = moment.parseZone(str).utc(); // Tue Oct 01 2024 08:00:00 GMT+0000
m2 = moment.parseZone(str).utc(true); // Tue Oct 01 2024 00:00:00 GMT+0000
console.log(m1.toString(), m2.toString());

m1 = moment(new Date("2024-02-29T20:59:59.123Z")).round(1, "minutes");
d1 = m1.hour(0).minute(0).toDate();
console.log(m1.toString(), d1.toString());

precision = 15;
key = "seconds";
m1 = moment("2023-02-22T00:00:13+02:00");
m2 = m1.round(precision, key);
console.log(m2.toDate(), precision, key);

precision = 1;
key = "minutes";
m1 = moment("2023-02-22T00:00:13+02:00");
m2 = m1.round(precision, key);
console.log(m2.toDate(), precision, key);

precision = 1;
key = "minutes";
//str = "2023-01-19T23:59:56+02:00";
str = "2023-01-19T23:59:56.000Z";
//str = "2024-02-29T23:59:59.123Z";
//str = "2023-04-09T23:59:59.123Z";
m1 = moment(str);
console.log(m1.toDate().toUTCString());
m2 = m1.round(precision, key);
console.log(m2.toDate().toUTCString(), precision, key, m2.isDST());
console.log(getOADate(str, true).toUTCString());

precision = 1;
key = "hours";
//str = "2023-01-19T23:59:56+02:00";
str = "2023-01-19T23:59:56.000Z";
//str = "2024-02-29T23:59:59.123Z";
//str = "2023-04-09T23:59:59.123Z";
m1 = moment(str);
console.log(m1.toDate().toUTCString());
m2 = m1.round(precision, key);
console.log(m2.toDate().toUTCString(), precision, key, m2.isDST());
console.log(getOADate(str, true).toUTCString());

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
console.log(m1.toDate().toUTCString());
m2 = m1.round(precision, key);
console.log(m2.toDate().toUTCString(), precision, key, m2.isDST());
console.log(getOADate(str, true).toUTCString());
