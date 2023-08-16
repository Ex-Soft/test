// https://stackoverflow.com/questions/17380845/how-do-i-convert-a-string-to-enum-in-typescript

const stringToEnumValue = <ET, T>(enumObj: ET, str: string): T =>
    (enumObj as any)[Object.keys(enumObj).filter(k => (enumObj as any)[k] === str)[0]];

//export const stringToEnumValue = <T, K extends keyof T>(enumObj: T, value: string): T[keyof T] | undefined =>
//    enumObj[Object.keys(enumObj).filter((k) => enumObj[k as K].toString() === value)[0] as keyof typeof enumObj];

enum SmthType {
    SmthType1 = "SMTH_TYPE_1",
    SmthType2 = "SMTH_TYPE_2",
    SmthType3 = "SMTH_TYPE_3"
}

let smthTypes = [SmthType.SmthType1, SmthType.SmthType3];
if (window && window.console) {
    let smthType = SmthType["SMTH_TYPE_3"]; // undefined
    console.log(smthTypes.indexOf(smthType)); // -1

    smthType = stringToEnumValue<typeof SmthType, SmthType>(SmthType, "SMTH_TYPE_3"); // "SMTH_TYPE_3"
    //smthType = stringToEnumValue(SmthType, "SMTH_TYPE_3"); // "SMTH_TYPE_3"
    console.log(smthTypes.indexOf(smthType)); // 1

    smthType = SmthType["SmthType3"]; // "SMTH_TYPE_3"
    console.log(smthTypes.indexOf(smthType)); // 1
}

enum Reason {
    None,
    First,
    Second,
    Third
}

let reason1: Reason;
let reason2: Reason;
let reasonNumber: number;

reason1 = Reason.First;
reason2 = 2;
reasonNumber = 3;
console.log("%o %o 3%s==Reason.Third", reason1, reason2, reasonNumber === Reason.Third ? "=" : "!");

enum Season {
    Winter,
    Spring = 1, // can assign integer 
    Summer,
    Fall
}

let summerNumber: number;

// summerNumber = 2
summerNumber = Season.Summer;

let summerName: string;

// summerName = "Summer"
summerName = Season[Season.Summer];

let season: Season;
season = Season["Fall"];

enum Direction {
    Up = "Up",
    Down = "Down",
    Left = "Left",
    Right = "Right"
}

let direction1: Direction;
let direction2: Direction;
direction1 = Direction["Down"]; // "Down"
direction2 = Direction["Middle"]; // undefined
if (window.console && console.log) {
    console.log("direction1=%o (typeof(%s)) direction2=%o (typeof(%s))", direction1, typeof direction1, direction2, typeof direction2);
}

let directionStr1 = Direction.Right; // "Right"
let directionStr2 = Direction[Direction.Right];  // "Right"
if (window.console && console.log) {
    console.log("directionStr1=\"%s\" directionStr2=\"%s\"", directionStr1, directionStr2);
}

let directionObj = {
    [Direction.Up]: Direction.Up,
    [Direction.Down]: Direction.Down,
    [Direction.Left]: Direction.Left,
    [Direction.Right]: Direction.Right
};
if (window.console && console.log) {
    console.log("%o %o %o", directionObj, typeof directionObj[Direction.Up], directionObj[Direction.Up]);
}

enum abc {
    a = 1,
    b = 2,
    c = 3
}

enum def {
    d = 4,
    e = 5,
    f = 6
}

type abcdef = abc | def;
let _abcdef_: abcdef;
_abcdef_ = abc.a;
_abcdef_ = def.d;

enum Operations {
    None = 0,
    Op1 = 1,
    Op2 = 2,
    Op3 = 4,
    Op4 = 8
}

let operations = Operations.Op2 | Operations.Op4;

if (window.console && console.log) {
    if (operations & Operations.Op2)
        console.log("%i %i %s", operations, Operations.Op2, "Op2");
    if (operations & Operations.Op3)
        console.log("%i %i %s", operations, Operations.Op3, "Op3");
    if (operations & Operations.Op4)
        console.log("%i %i %s", operations, Operations.Op4, "Op4");
}
