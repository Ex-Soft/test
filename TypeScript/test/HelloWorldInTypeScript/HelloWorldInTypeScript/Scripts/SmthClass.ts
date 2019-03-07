class SmthClass implements ISmthInterface {
    pString1 = "pString1Value";
    pString2 = "pString2Value";
    pString3 = "pString3Value";
    pString4: string;

    constructor(public aString1?: string, public aString2?: string) {
        this.pString1 = aString1;
        this.pString2 = aString2;
    }

    public output(): void {
        if (window.console && console.log)
            console.log("{pString1:\"%s\", pString2:\"%s\", pString3:\"%s\", pString4:\"%s\"}", this.pString1, this.pString2, this.pString3, this.pString4);
    }
}

let smthClass = new SmthClass("p1StringValue (from constructor)");
smthClass.output();
