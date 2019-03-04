class Employee extends Person {
    private _employeeNumber: number;
    get EmployeeNumber() {
        return this._employeeNumber;
    }

    // property overriding sample
    get LastName() {
        return "SuperCaleFlageolisticExpialodocios";
    }

    constructor(employeeNumber: number, firstName: string, lastName: string) {
        // call constructor of the super class
        super(firstName, lastName);

        this._employeeNumber = employeeNumber;
    }
}

// function that takes Person object
// and displays it within alert dialog
function PrintPersonFullName(person: Person): void {
    if (window.console && console.log)
        console.log(person.FullName);
}

// create Employee object
let joeDoeEmployee: Person = new Employee(1, "Joe", "Doe");

// call PrintPersonFullName function on
// the joeDoeEmployee object
PrintPersonFullName(joeDoeEmployee);
