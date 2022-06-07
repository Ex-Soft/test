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
            console.log("{pString1:\"%s\", pString2:\"%s\", pString3:\"%s\", pString4:\"%s\"} (from output())", this.pString1, this.pString2, this.pString3, this.pString4);
    }

    public toString(): string {
        return `{pString1:\"${this.pString1}\", pString2:\"${this.pString2}\", pString3:\"${this.pString3}\", pString4:\"${this.pString4}\"} (from to String())`;
    }

    public valueOf(): string {
        return `{pString1:\"${this.pString1}\", pString2:\"${this.pString2}\", pString3:\"${this.pString3}\", pString4:\"${this.pString4}\"} (from valueOf())`;
    }
}

let smthClass = new SmthClass("p1StringValue (from constructor)");
smthClass.output();

let smthClass2 = { ...smthClass };
if (window.console && console.log) {
    console.log("o2 = { ...o1 } => %o %o", smthClass2, smthClass);
    console.log("%%s = %s", smthClass);
    console.log("\"\" + object = " + smthClass);
    console.log(`${smthClass}`);
    console.log(smthClass.toString());
    console.log(smthClass.valueOf());
}
