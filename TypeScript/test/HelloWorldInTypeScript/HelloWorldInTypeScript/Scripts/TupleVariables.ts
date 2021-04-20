let myTuple: [number, string, boolean];

myTuple = [123, "123", true]; // works fine

//myTuple = [123, 123, 123]; // compiler error

function functionReturnsTuple() {
    const obj = {
        pInt: 1,
        pString: "string",
        pNull: null,
        pUndefined: undefined
    };

    return [obj.pInt, obj.pString, obj.pNull, obj.pUndefined];
}

let resultTuple = functionReturnsTuple();
console.log(typeof resultTuple, Array.isArray(resultTuple));
