const tmpObject1 = {
    id: 1,
    value: "1"
};

for (const p of Object.keys(tmpObject1)) {
    if (window.console && console.log) {
        console.log(p);
    }
}

Object.keys(tmpObject1).forEach(key => console.log("tmpObject1[%s]=%o", key, tmpObject1[key as keyof typeof tmpObject1]))

interface ISmthInterface3 {
    id?: number;
    value?: string;
    o?: ISmthInterface3;
}

let tmpObject2 = {
    id: 1,
    value: "1"
} as ISmthInterface3;

let tmpObject3 = { ...tmpObject2 };
if (window.console && console.log) {
    console.log("o2 = { ...o1 } => %o %o", tmpObject2, tmpObject3);
}

const objectDestructuringAssignmentFn1 = ({ id }: ISmthInterface3) => {
    if (window.console && console.log) {
        console.log("objectDestructuringAssignmentFn1(%o)", id);
    }
}

const objectDestructuringAssignmentFn2 = ({ id, value }: ISmthInterface3) => {
    if (window.console && console.log) {
        console.log("objectDestructuringAssignmentFn2(%o, %o)", id, value);
    }
}

objectDestructuringAssignmentFn1(tmpObject2);
objectDestructuringAssignmentFn2(tmpObject2);

let tmpObject = tmpObject2?.o?.o?.value;
if (window.console && console.log) {
    console.log("(elvis) %o", tmpObject);
}

tmpObject2.o = {
    id: 11,
    value: "11"
} as ISmthInterface3;
tmpObject = tmpObject2?.o?.o?.value;
if (window.console && console.log) {
    console.log("(elvis) %o", tmpObject);
}

tmpObject2.o.o = {
    id: 111,
    value: "111"
} as ISmthInterface3;
tmpObject = tmpObject2?.o?.o?.value;
if (window.console && console.log) {
    console.log("(elvis) %o", tmpObject);
}

const equals = (a: any, b: any): boolean => {
    if (isObject(a) && isObject(b)) {
        const k1 = Object.keys(a);
        const k2 = Object.keys(b);

        if (k1.length !== k2.length)
            return false;

        for (let i = 0, l = k1.length; i < l; ++i) {
            const prop = k1[i];
            if (!b.hasOwnProperty(prop) || !equals(a[prop], b[prop]))
                return false;
        }

        return true;
    } else if (isDate(a) && isDate(b)) {
        return a.getTime() === b.getTime();
    } else {
        return a === b;
    }
};

const isObject = (value: any): boolean => {
    return value && toString.call(value) === "[object Object]";
};

const isDate = (value: any): boolean => {
    return value && (value instanceof Date || toString.call(value) === "[object Date]") && value.toString() !== "Invalid Date";
};

if (window.console && console.log) {
    console.log("equals(1, 1) = %o", equals(1, new Number(1)));
    console.log("equals(1, {}) = %o", equals(1, {}));
    console.log("equals({}, {}) = %o", equals({}, {}));
    console.log("equals({ id: 1 }, { id: 1 }) = %o", equals({ id: 1 }, { id: 1 }));
    console.log("equals({ id: 1 }, { id: 2 }) = %o", equals({ id: 1 }, { id: 2 }));
    console.log("equals({ id: 1 }, { id: 1, value: \"\" }) = %o", equals({ id: 1 }, { id: 1, value: "" }));
    console.log("equals(new Date(2021, 1, 28), new Date(2021, 1, 28)) = %o", equals(new Date(2021, 1, 28), new Date(2021, 1, 28)));
}

let tmpString1 = undefined, tmpString2 = null, tmpString3 = "tmpString3", tmpString;
tmpString = tmpString1 ?? tmpString2 ?? tmpString3;
if (window.console && console.log) {
    console.log("tmpString=\"%s\"", tmpString);
}

tmpString = tmpString1 || tmpString2 || tmpString3;
if (window.console && console.log) {
    console.log("tmpString=\"%s\"", tmpString);
}

let tmpBool: boolean;
tmpObject2 = {
    id: 1,
    value: "1",
    o: {} as ISmthInterface3
} as ISmthInterface3;
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value != undefined; // false
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value !== undefined; // false
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value != null; // false
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value !== null; // true
tmpBool = tmpObject2 && tmpObject2.o && !!tmpObject2.o.value; // false

tmpObject2 = {
    id: 1,
    value: "1",
    o: {
        value: undefined
    } as ISmthInterface3
} as ISmthInterface3;
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value != undefined; // false
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value !== undefined; // false
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value != null; // false
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value !== null; // true
tmpBool = tmpObject2 && tmpObject2.o && !!tmpObject2.o.value; // false

tmpObject2 = {
    id: 1,
    value: "1",
    o: {
        value: null
    } as ISmthInterface3
} as ISmthInterface3;
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value != undefined; // false
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value !== undefined; // true
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value != null; // false
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value !== null; // false
tmpBool = tmpObject2 && tmpObject2.o && !!tmpObject2.o.value; // false

tmpObject2 = {
    id: 1,
    value: "1",
    o: {
        id: 11,
        value: "11"
    } as ISmthInterface3
} as ISmthInterface3;
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value != undefined; // true
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value !== undefined; // true
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value != null; // true
tmpBool = tmpObject2 && tmpObject2.o && tmpObject2.o.value !== null; // true
tmpBool = tmpObject2 && tmpObject2.o && !!tmpObject2.o.value; // true
