class ClassWithId {
    constructor(public id?: string) {
    }
}

class ClassWithClosures {
    constructor(public id?: ClassWithId) {
    }

    public isMatch = (num: number): boolean => {
        return this.id && !!this.id.id && num % 2 === 0;
    }
}

let arrayOfInt = [1, 2, 3, 4, 5, 6, 7, 8, 9];

let classWithClosure = new ClassWithClosures();
let resultOfFilter = arrayOfInt.filter(classWithClosure.isMatch);
if (window.console && console.log) {
    console.log("resultOfFilter.length=%i", resultOfFilter.length);
}

classWithClosure = new ClassWithClosures(new ClassWithId());
resultOfFilter = arrayOfInt.filter(classWithClosure.isMatch);
if (window.console && console.log) {
    console.log("resultOfFilter.length=%i", resultOfFilter.length);
}

classWithClosure = new ClassWithClosures(new ClassWithId("blah"));
resultOfFilter = arrayOfInt.filter(classWithClosure.isMatch);
for (let i = 0, l = resultOfFilter.length; i < l; i++) {
    if (window.console && console.log) {
        console.log(resultOfFilter[i]);
    }
}
