const fs = require("fs");
const csv = require("csvtojson");

const fileName = "test.csv";

try {
  if (!fs.existsSync(fileName, fs.constants.F_OK)) return;

  csv({
    colParser: {
      pNumber: "number",
      pDate: function (item, head, resultRow, row, colIdx) {
        return new Date(item);
      },
    },
  })
    .fromFile(fileName)
    .then(
      (jsonObj) => {
        console.log(jsonObj);
      },
      (error) => {
        console.log(error);
      }
    )
    .catch((error) => {
      console.log(error);
    });
} catch (error) {
  console.log(error);
}
