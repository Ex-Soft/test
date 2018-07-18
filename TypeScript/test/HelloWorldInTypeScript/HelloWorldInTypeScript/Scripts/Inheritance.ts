class BaseClass {
    bp1: string;

    constructor(bp1: string) {
        this.bp1 = bp1;
    }

    foo1() {
        if (window.console && console.log)
            console.log("bp1: \"%s\"", this.bp1);
    }
}

class DerivedClass extends BaseClass {
    dp1: string;

    constructor(bp1: string, dp1: string) {
        super(bp1);

        this.dp1 = dp1;
    }

    foo1() {
        super.foo1();

        if (window.console && console.log)
            console.log("dp1: \"%s\"", this.dp1);
    }
}

let baseClass = new BaseClass("BaseClass property# 1");
let derivedClass = new DerivedClass("BaseClass property# 1", "DerivedClass property# 1");

baseClass.foo1();
derivedClass.foo1();
