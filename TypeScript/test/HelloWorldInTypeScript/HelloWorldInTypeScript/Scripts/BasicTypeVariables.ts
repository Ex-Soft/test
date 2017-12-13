// define number
let myNumber: number;
myNumber = 5;

// define string
let myString: string;

// define any (can take any type
// - analogous to object in C#)
let myAny1: any = null;

// no type specified analogous to 'any'
let myAny2;

// initialised to boolean
// even though the type is not specified
// you cannot change the type later
let myBool1 = true;
//myBool1 = 1;

// type specified and initialize to false
let myBool2: boolean = false;

// compiler error
// cannot reassign the type to 'number'
//myString = 5;

myAny1 = 5; //OK

// OK
myAny2 = "hello world";

// any can be reassigned any type (like object in C#)
myAny1 = "Hi";

// casting:
// the two expressions below 
// are equivalent.
myString = myAny2 as string;
myString = (<string>myAny2);
