const arrayOfString = ["1st", "3rd", "2nd", "4th", "2nd", "1st"];
const setOfString = new Set(arrayOfString);

if (window.console && console.log) {
    for (let volatileItem of setOfString) {
        console.log("let \"%s\"", volatileItem);
    }

    for (const constItem of setOfString) {
        console.log("const \"%s\"", constItem);
    }
}