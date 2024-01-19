// eslint-disable-next-line @typescript-eslint/no-explicit-any
export const isString = (value: any): boolean => {
  return typeof value === "string";
};

// eslint-disable-next-line @typescript-eslint/no-explicit-any
export const isFunction = (value: any): boolean => {
  return (
    value &&
    (typeof value === "function" ||
      value instanceof Function ||
      toString.call(value) === "[object Function]")
  );
};

// eslint-disable-next-line @typescript-eslint/no-explicit-any
export const isObject = (value: any): boolean => {
  return value && toString.call(value) === "[object Object]";
};

// eslint-disable-next-line @typescript-eslint/no-explicit-any
export const isDate = (value: any): boolean => {
  return (
    value &&
    (value instanceof Date || toString.call(value) === "[object Date]") &&
    value.toString() !== "Invalid Date"
  );
};

// eslint-disable-next-line @typescript-eslint/no-explicit-any
export const isNumber = (value?: any): boolean => {
  return typeof value === "number" && isFinite(value);
};

// eslint-disable-next-line @typescript-eslint/no-explicit-any
export const isNumeric = (value?: any): boolean => {
  return !isNaN(parseFloat(value)) && isFinite(value);
};
