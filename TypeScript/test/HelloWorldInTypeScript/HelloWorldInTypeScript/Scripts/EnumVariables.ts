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

function GetEnumKeyByValue<T extends { [index: string]: string }>(
    myEnum: T,
    enumValue: string
): keyof T | null {
    const keys = Object.keys(myEnum).filter((x) => myEnum[x] == enumValue)
    return keys.length > 0 ? keys[0] : null
}

enum DealerType {
    PREFERRED_DEALER = 'preferred_dealer',
    TOP_EVENT_DEALER = 'top_event_dealer',
    HEB_DEALER = 'heb_dealer',
}

if (window.console && console.log) {
    const found = GetEnumKeyByValue(DealerType, 'top_event_dealer')
    if (found) console.log(DealerType[found])
}

for (let key in Object.keys(Reason)) {
    if (window.console && console.log) {
        console.log("key=%s Reason[%s]=\"%s\"", key, key, Reason[key]);
    }
}
/*
key=0 Reason[0]="None"
key=1 Reason[1]="First"
key=2 Reason[2]="Second"
key=3 Reason[3]="Third"
key=4 Reason[4]="undefined"
key=5 Reason[5]="undefined"
key=6 Reason[6]="undefined"
key=7 Reason[7]="undefined"
*/

for (let p in Reason) {
    if (window.console && console.log) {
        console.log("p=%s Reason[%s]=\"%s\"", p, p, Reason[p]);
    }
}
/*
p=0 Reason[0]="None"
p=1 Reason[1]="First"
p=2 Reason[2]="Second"
p=3 Reason[3]="Third"
p=None Reason[None]="0"
p=First Reason[First]="1"
p=Second Reason[Second]="2"
p=Third Reason[Third]="3"
*/

for (let key in Object.keys(DealerType)) {
    if (window.console && console.log) {
        console.log("key=%s DealerType[%s]=\"%s\"", key, key, DealerType[key]);
    }
}
/*
key=0 DealerType[0]="undefined"
key=1 DealerType[1]="undefined"
key=2 DealerType[2]="undefined"
*/

for (let p in DealerType) {
    if (window.console && console.log) {
        console.log("p=%s DealerType[%s]=\"%s\"", p, p, DealerType[p]);
    }
}
/*
p=PREFERRED_DEALER DealerType[PREFERRED_DEALER]="preferred_dealer"
p=TOP_EVENT_DEALER DealerType[TOP_EVENT_DEALER]="top_event_dealer"
p=HEB_DEALER DealerType[HEB_DEALER]="heb_dealer"
*/
