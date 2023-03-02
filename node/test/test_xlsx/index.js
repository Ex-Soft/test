let basedate = new Date(2209161600000);
console.log("%s %o", basedate.toString(), basedate.getTimezoneOffset());
basedate = new Date(-2209161600000);
console.log("%s %o", basedate.toString(), basedate.getTimezoneOffset());
basedate = new Date(1899, 11, 30, 0, 0, 0); // 2209161600000
console.log("%s %o %o %o", basedate.toString(), basedate.getTime(), basedate.valueOf(), basedate.getTimezoneOffset());
console.log(new Date(1899, 11, 30, 0, 0, 0).getTimezoneOffset());
console.log ((2209168924000 - 2209161600000)/60000);
console.log ((2209168924000 - 124000 - 2209161600000)/60000);

const filename = "test_xlsx.xlsx";

const XLSX = require("xlsx");

const wb = XLSX.readFile(filename, { sheetStubs: true, cellDates: true/*, dateNF: 'yyyy-mm-dd'*/ });
const ws = wb.Sheets["Sheet1"];
const data = XLSX.utils.sheet_to_json(ws);

if (Array.isArray(data) && data.length)
    console.log(data[0]);
