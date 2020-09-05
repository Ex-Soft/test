let arrayOfStrings = ["str1", "str2", "str3"];

// myStr="str1"
let myStr = arrayOfStrings[0];

// compiler error
// cannot assign an array of numbers
// to an array of string.
//arrayOfStrings = [1, 2, 3];

// can contain any types like List<object> in C#
let arrayOfAny: any[] = [1, "str2", false];

// for any[] reassigning to an array 
// containing different types works fine
arrayOfAny = [true, 2, "str3"];

// another way to define array of strings
// by using Array<string>
let arrayOfStrings2: Array<string>;

// now arrayOfStrings2 contains ["str1", "str2", "str3", "str4"]
arrayOfStrings2 = [...arrayOfStrings, "str4"];

let i = 5;

let complexObject = {
    groups: [
        {
            items: [{ id: 1 }, { id: 2 }]
        },
        {
            items: [{ id: 3 }, { id: 4 }]
        }
    ]
};

let items = complexObject.groups.reduce((acc, val) => acc.concat(val.items), []);
if (window.console && console.log)
    console.log(items);
