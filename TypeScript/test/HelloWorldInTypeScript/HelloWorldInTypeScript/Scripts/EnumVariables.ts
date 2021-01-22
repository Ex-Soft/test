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

let directionStr1 = Direction.Right;
let directionStr2 = Direction[Direction.Right];
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
