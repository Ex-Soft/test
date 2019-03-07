class DerivedClass extends BaseClass {
    constructor(public baseProp1: string, public derivedProp1: string) {
        super(baseProp1);
        this.derivedProp1 = derivedProp1;
    }

    public output(): void {
        super.output();

        if (window.console && console.log)
            console.log("{derivedProp1:\"%s\"}", this.derivedProp1);
    }
}
