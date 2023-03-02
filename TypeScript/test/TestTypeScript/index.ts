enum SmthEnumWithStringValues {
    SMTH_VALUE_1 = "SmthValue1",
    SMTH_VALUE_2 = "SmthValue2",
    SMTH_VALUE_3 = "SmthValue3"
}

const stringToEnumValue1 = <ET, T>(enumObj: ET, str: string): T =>
    (enumObj as any)[Object.keys(enumObj).filter(k => (enumObj as any)[k] === str)[0]];

const stringToEnumValue2 = <T, K extends keyof T>(enumObj: T, value: string): T[keyof T] | undefined =>
    enumObj[Object.keys(enumObj).filter((k) => enumObj[k as K].toString() === value)[0] as keyof typeof enumObj];

function GetEnumKeyByValue<T extends { [index: string]: string }>(
    myEnum: T,
    enumValue: string
): keyof T | null {
    const keys = Object.keys(myEnum).filter((x) => myEnum[x] == enumValue);
    return keys.length > 0 ? keys[0] : null;
};

let smthEnumValue = stringToEnumValue1(SmthEnumWithStringValues, "SmthValue2");
console.log(smthEnumValue);
smthEnumValue = stringToEnumValue2(SmthEnumWithStringValues, "SmthValue3");
console.log(smthEnumValue);
smthEnumValue = GetEnumKeyByValue(SmthEnumWithStringValues, "SmthValue1");
console.log(smthEnumValue);