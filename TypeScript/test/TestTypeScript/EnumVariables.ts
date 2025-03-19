enum SmthEnumWithNumberValues {
    UNKNOWN,
    FIRST,
    SECOND,
    THIRD,
    FOURTH,
    FIFTH
}

const smthEnumWithNumberValuesKeyLabel = Object.entries(SmthEnumWithNumberValues)
    .filter(([key]) => {
        return parseInt(key);
    }) as [string, string][];

const smthEnumWithNumberValuesOptions = smthEnumWithNumberValuesKeyLabel.map(([value, label]) => ({
    value,
    label: `${label.charAt(0)}${label.slice(1).toLowerCase()}`,
}))

enum SmthEnumWithStringValues {
    SMTH_VALUE_1 = "SmthValue1",
    SMTH_VALUE_2 = "SmthValue2",
    SMTH_VALUE_3 = "SmthValue3"
}

const smthEnumWithStringValuesKeyLabel = Object.entries(SmthEnumWithStringValues)
    .filter(([key]) => {
        return key;
    }) as [string, string][];

const smthEnumWithStringValuesOptions = smthEnumWithStringValuesKeyLabel.map(([value, label]) => ({
    value,
    label: `${label.charAt(0)}${label.slice(1).toLowerCase()}`,
}))

const stringToEnumValue1 = <ET, T>(enumObj: ET, str: string): T =>
    (enumObj as any)[Object.keys(enumObj as {}).filter(k => (enumObj as any)[k] === str)[0]];

const stringToEnumValue2 = <T, K extends keyof T>(enumObj: T, str: string): T[keyof T] | undefined =>
    enumObj[Object.keys(enumObj as {}).filter(k => (enumObj[k as K] as any).toString() === str)[0] as keyof typeof enumObj];

function GetEnumKeyByValue<T extends { [index: string]: string }>(
    myEnum: T,
    enumValue: string
): keyof T | null {
    const keys = Object.keys(myEnum).filter(x => myEnum[x] === enumValue);
    return keys.length > 0 ? keys[0] : null;
};

export function TestEnumVariables() {
    Object.entries(SmthEnumWithNumberValues)
        .forEach(item => {
            console.log(item);
        });
    Object.entries(SmthEnumWithNumberValues)
        .forEach(([key]) => {
            console.log(key);
        });
    Object.entries(SmthEnumWithNumberValues)
        .forEach(([key, value]) => {
            console.log(key, value);
        });
    console.log(smthEnumWithNumberValuesKeyLabel);
    console.log(smthEnumWithNumberValuesOptions);

    Object.entries(SmthEnumWithStringValues)
        .forEach(item => {
            console.log(item);
        });
    Object.entries(SmthEnumWithStringValues)
        .forEach(([key]) => {
            console.log(key);
        });
    Object.entries(SmthEnumWithStringValues)
        .forEach(([key, value]) => {
            console.log(key, value);
        });
    console.log(smthEnumWithStringValuesKeyLabel);
    console.log(smthEnumWithStringValuesOptions);

    let smthEnumValue = stringToEnumValue1(SmthEnumWithStringValues, "SmthValue2");
    console.log(smthEnumValue);
    smthEnumValue = stringToEnumValue2(SmthEnumWithStringValues, "SmthValue3");
    console.log(smthEnumValue);
    smthEnumValue = GetEnumKeyByValue(SmthEnumWithStringValues, "SmthValue1");
    console.log(smthEnumValue);
}