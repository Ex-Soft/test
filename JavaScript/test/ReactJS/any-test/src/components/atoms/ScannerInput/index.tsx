import { useState, useRef, useEffect } from "react";
import { debounce } from "lodash";
import "./index.css";

const isFunction = (value: any): boolean => {
  return (
    value &&
    (typeof value === "function" ||
      value instanceof Function ||
      toString.call(value) === "[object Function]")
  );
};

const isDigit = (str: string) => !/\D/.test(str);
const isAlphanumeric = (str: string) => !/[^0-9a-z]/i.test(str);

export interface ScannerInputValue {
  isCode?: boolean;
  value?: string;
}

export type ScannerInputProps = {
  codeLength?: number | number[];
  wait?: number;
  onChange?: (value?: ScannerInputValue) => void;
  allowAlphanumeric?: boolean;
};

interface ScannerInputState {
  value?: string;
  lastValue?: string;
}

const checkCode = (
  value?: string,
  lastValue?: string,
  codeLength?: number | number[],
  allowAlphanumeric?: boolean
) => {
  const isNotCodeResult = { isCode: false, code: undefined };

  if (!codeLength) {
    return isNotCodeResult;
  }

  if (!Array.isArray(codeLength)) {
    codeLength = [codeLength];
  }

  const testFn = allowAlphanumeric === true ? isAlphanumeric : isDigit;

  for (let i = 0, l = codeLength.length; i < l; ++i) {
    let code,
      _codeLength = codeLength[i];

    const isCode =
      !!value &&
      value.length - (lastValue?.length || 0) === _codeLength &&
      testFn((code = value.slice(-_codeLength)));

    if (isCode) {
      return { isCode, ...(isCode && { code }) };
    }
  }

  return isNotCodeResult;
};

const ScannerInput: React.FC<ScannerInputProps> = ({
  codeLength = undefined,
  wait = undefined,
  onChange = undefined,
  allowAlphanumeric = undefined,
}) => {
  console.log("ScannerInput() started");

  const [state, setState] = useState<ScannerInputState | null | undefined>({
    value: "",
    lastValue: "",
  });

  const delayCall = useRef(
    debounce(
      (
        value?: string,
        state?: ScannerInputState | null,
        setState?: Function,
        codeLength?: number | number[],
        onChange?: Function
      ) => {
        console.log('delayCall("%s") started { value: "%s", lastValue: "%s" }', value, state?.value, state?.lastValue);

        const { isCode, code } = checkCode(
          value,
          state?.lastValue,
          codeLength,
          allowAlphanumeric
        );

        if (isFunction(setState)) {
          if (isCode) {
            setState?.({ value: code, lastValue: code });
            console.log('code - %s { value: "%s", lastValue: "%s" }', code, state?.value, state?.lastValue);
          } else {
            setState?.({ lastValue: value });
            console.log('search - %s { value: "%s", lastValue: "%s" }', value, state?.value, state?.lastValue);
          }
        }

        if (isFunction(onChange)) {
          onChange?.({ isCode, value: isCode ? code : value });
        }

        console.log('delayCall("%s") finished { value: "%s", lastValue: "%s" }', value, state?.value, state?.lastValue);
      },
      wait
    )
  ).current;

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const value = e.target.value;

    setState({ value });
    console.log('before delayCall("%s") { value: "%s", lastValue: "%s" }', value, state?.value, state?.lastValue);
    delayCall(value, state, setState, codeLength, onChange);
    console.log('after delayCall("%s") { value: "%s", lastValue: "%s" }', value, state?.value, state?.lastValue);
  };

  useEffect(() => {
    return () => {
      delayCall.cancel();
    };
  }, [delayCall]);

  console.log("ScannerInput() finished");

  return (
    <input type="text" value={state?.value} onChange={(e) => handleChange(e)} />
  );
};

export default ScannerInput;
