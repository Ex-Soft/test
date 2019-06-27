class ClassWithStatic {
    static staticP1: string = "staticP1";

    constructor(private privateP1: string) {
    }

    static WriteToLog(msg: string) {
        if (window.console && console.log)
            console.log(msg);
    }

    smthFunc1() {
        if (window.console && console.log)
            console.log("smthFunc1(%o)", arguments);
    }

    smthFunc2 = function() {
        if (window.console && console.log)
            console.log("smthFunc2(%o)", arguments);
    }
}
