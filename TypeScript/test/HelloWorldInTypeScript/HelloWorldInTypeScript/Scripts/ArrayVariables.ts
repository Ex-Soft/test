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

const unique = (arr: any[]): any[] => {
    const indexOf = (array: any[], value: any) => {
        const isObject = typeof value === "object";

        for (let i = 0, l = array.length; i < l; ++i) {
            if (isObject) {
                const item = array[i];
                let isAllEqual = true;

                for (const p of Object.keys(value)) {
                    isAllEqual = isAllEqual && item.hasOwnProperty(p) && item[p] === value[p];
                    if (!isAllEqual) {
                        break;
                    }
                }

                if (isAllEqual) {
                    return i;
                }
            } else {
                if (array[i] === value) {
                    return i;
                }
            }
        }

        return -1;
    };

    return Array.isArray(arr) ? arr.filter((val, idx, self) => indexOf(self, val) === idx) : [];
};

arrayOfAny = [1, 2, 3, 4, 3, 2, 1];
arrayOfAny = unique(arrayOfAny);
if (window.console && console.log) {
    console.log("unique() = %o", arrayOfAny);
}

arrayOfAny = [
    { id: 1, value: "1st" },
    { id: 1, value: "1st" },
    { id: 3, value: "3rd" },
];
arrayOfAny = unique(arrayOfAny);
if (window.console && console.log) {
    console.log("unique() = %o", arrayOfAny);
}

const identity = <T>(entity: T) => entity;
const distinct = <T>(arr: T[], getKey: (obj: T) => unknown = identity): T[] => Array.isArray(arr) ? arr.filter((item, index, array) => array.findIndex((t) => getKey(t) === getKey(item)) === index) : [];

arrayOfAny = [
    { id: 1, value: "1st" },
    { id: 1, value: "1st" },
    { id: 3, value: "3rd" },
];
arrayOfAny = distinct(arrayOfAny, obj => obj.id);
if (window.console && console.log) {
    console.log("distinct() = %o", arrayOfAny);
}
