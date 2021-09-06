class ClassWithGettersAndSetters {
    private _p1: string;
    private _p2: string;

    get p1() {
        if (window.console && console.log)
            console.log("ClassWithGettersAndSetters.get_p1() %o", this._p1);
        return this._p1;
    }

    set p1(value) {
        if (window.console && console.log)
            console.log("ClassWithGettersAndSetters.set_p1(%o)", value);
        this._p1 = value;
    }

    get p2() {
        if (window.console && console.log)
            console.log("ClassWithGettersAndSetters.get_p2() %o", this._p2);
        return this._p2;
    }

    set p2(value) {
        if (window.console && console.log)
            console.log("ClassWithGettersAndSetters.set_p2(%o)", value);
        this._p2 = value;
    }

    constructor(p1?: string, p2?: string) {
        this._p1 = p1;
        this._p2 = p2;
    }
}

let classWithGettersAndSetters = new ClassWithGettersAndSetters("p1Value");
classWithGettersAndSetters.p2 = "p2Value";
if (window.console && console.log)
    console.log("ClassWithGettersAndSetters = %o", classWithGettersAndSetters);
