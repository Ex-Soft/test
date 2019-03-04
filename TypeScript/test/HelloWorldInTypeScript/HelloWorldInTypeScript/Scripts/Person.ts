class Person implements IPerson {
    //#region
    // read-write property FirstName
    private _firstName: string;
    get FirstName(): string {
        return this._firstName;
    }
    set FirstName(value: string) {
        this._firstName = value;
    }
    //#endregion

    //#region
    // read-write property LastName
    private _lastName: string;
    get LastName(): string {
        return this._lastName;
    }
    set LastName(value: string) {
        this._lastName = value;
    }
    //#endregion

    // read-only property FullName
    get FullName(): string {
        let result: string = "";

        if (this.FirstName) {
            result += this.FirstName;
            result += " ";
        }

        if (this.LastName) {
            result += this.LastName;
        }

        return result;
    }

    // constructor taking two optional arguments
    constructor(firstName?: string, lastName?: string) {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}

let people: Array<Person>;

people = [new Person("Joe", "Doe"), new Person("Jane", "Dane")];

let result: string = "";

for (let person of people) {
    result += person.FullName + "\n";
}

if (window.console && console.log)
    console.log(result);

let PrintFullName = (person: IPerson) => {
    let result: string = "";

    if (person.FirstName) {
        result += person.FirstName + " ";
    }

    if (person.MiddleName) {
        result += person.MiddleName + " ";
    }

    if (person.LastName) {
        result += person.LastName;
    }

    if (window.console && console.log)
        console.log(result);
}

PrintFullName(new Person("Joe", "Doe"));

// create anonymous class
let person = new class implements IPerson {
    private _firstName: string;
    get FirstName(): string {
        return this._firstName;
    }
    set FirstName(value: string) {
        this._firstName = value;
    }


    private _lastName: string;
    get LastName(): string {
        return this._lastName;
    }
    set LastName(value: string) {
        this._lastName = value;
    }

    constructor(firstName: string, lastName: string) {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}("Joe", "Doe"); // call constructor

PrintFullName(person);