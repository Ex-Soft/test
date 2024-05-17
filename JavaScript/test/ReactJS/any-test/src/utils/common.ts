export const isString = (value: any): boolean => {
  return typeof value === "string";
};

export const isFunction = (value: any): boolean => {
  return (
    value &&
    (typeof value === "function" ||
      value instanceof Function ||
      toString.call(value) === "[object Function]")
  );
};

export const isObject = (value: any): boolean => {
  return value && toString.call(value) === "[object Object]";
};

export const isDate = (value: any): boolean => {
  return (
    value &&
    (value instanceof Date || toString.call(value) === "[object Date]") &&
    value.toString() !== "Invalid Date"
  );
};

export const isNumber = (value?: any): boolean => {
  return typeof value === "number" && isFinite(value);
};

export const isNumeric = (value?: any): boolean => {
  return !isNaN(parseFloat(value)) && isFinite(value);
};

export const isBoolean = (value?: any): boolean => {
  return typeof value === "boolean";
};
