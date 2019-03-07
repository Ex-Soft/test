class TestClass {
    constructor(public string1: string, public string2?: string) {

    }

    public output(): void {
        if (window.console && console.log)
            console.log("{pString1:\"%s\", pString2:\"%s\"}", this.string1, this.string2);
    }
}

let testClass1 = new TestClass("string1value");
testClass1.output();
