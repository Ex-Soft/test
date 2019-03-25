class ClassWithSmthInterface2 implements ISmthInterface2 {
    foo1 = function () {
        if (window.console && console.log)
            console.log("foo1()");
    }

    foo2() {
        if (window.console && console.log)
            console.log("foo2()");
    }
}

let classWithSmthInterface2 = new ClassWithSmthInterface2();
classWithSmthInterface2.foo1();
classWithSmthInterface2.foo2();