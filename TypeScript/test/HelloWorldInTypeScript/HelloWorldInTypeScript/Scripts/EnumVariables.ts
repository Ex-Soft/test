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
