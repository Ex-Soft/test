interface IInterface4Cast1 {
    p1string: string;
    p1number: number;
    p1boolean: boolean;
}

let objToCast = {
    a: "a",
    b: "b",
    c: "c"
}

let objDestination = castToIInterface4Cast1(objToCast);

function isIInterface4Cast1(obj: any): boolean {
    return Boolean(obj as IInterface4Cast1);
}

function castToIInterface4Cast1(obj: any): IInterface4Cast1 {
    return obj as IInterface4Cast1;
}