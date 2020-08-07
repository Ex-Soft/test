class ClassForTestPartial implements IForTestPartial {
    constructor(public pString1: string, public pString2: string) {}
}

function updateObj(obj: IForTestPartial, fieldsToUpdate: Partial<IForTestPartial>) {
    return { ...obj, ...fieldsToUpdate };
}

function createObj(params: Partial<IForTestPartial>) {
    return {
        ...params
    } as IForTestPartial;
}

let obj = {
    pString1: "obj.pString1Value",
    pString2: "obj.pString2Value"
};

let newObj = updateObj(obj, {
    pString2: "newObj.pString2Value"
});

newObj = createObj({ pString3: "newObj.pString3Value" });