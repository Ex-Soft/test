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