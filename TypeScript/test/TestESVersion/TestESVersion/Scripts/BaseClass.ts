class BaseClass {
    constructor(public baseProp1: string) {
        this.baseProp1 = baseProp1;
    }

    public output(): void {
        if (window.console && console.log)
            console.log("{baseProp1:\"%s\"}", this.baseProp1);
    }
}
