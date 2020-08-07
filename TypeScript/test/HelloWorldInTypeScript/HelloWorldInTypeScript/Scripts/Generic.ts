class SmthClassForTestGeneric {
    constructor(public p1: string) {}
}

class BaseGenericClass<T> {
    bp1: T;

    constructor(bp1: T) {
        this.bp1 = bp1;
    }

    foo1(): T {
        if (window.console && console.log)
            console.log("bp1: \"%s\"", this.bp1);
        return this.bp1;
    }
}

class DerivedGenericClass<T> extends BaseGenericClass<T> {
    dp1: T;

    constructor(bp1: T, dp1: T) {
        super(bp1);

        this.dp1 = dp1;
    }

    foo1(): T {
        super.foo1();

        if (window.console && console.log)
            console.log("dp1: \"%s\"", this.dp1);

        return this.dp1;
    }
}

class DerivedGenericConcreteClass extends BaseGenericClass<SmthClassForTestGeneric> {
    dp1: SmthClassForTestGeneric;

    constructor(bp1: SmthClassForTestGeneric, dp1: SmthClassForTestGeneric) {
        super(bp1);

        this.dp1 = dp1;
    }

    foo1(): SmthClassForTestGeneric {
        super.foo1();

        if (window.console && console.log)
            console.log("dp1: \"%s\"", this.dp1);

        return this.dp1;
    }
}

let baseGenericClass = new BaseGenericClass<string>("BaseGenericClass property# 1");
let derivedGenericClass = new DerivedGenericClass<string>("BaseGenericClass property# 1", "DerivedGenericClass property# 1");
let derivedGenericConcreteClass = new DerivedGenericConcreteClass(new SmthClassForTestGeneric("BaseGenericConcreteClass property# 1"), new SmthClassForTestGeneric("DerivedGenericConcreteClass property# 1"));

baseGenericClass.foo1();
derivedGenericClass.foo1();
derivedGenericConcreteClass.foo1();