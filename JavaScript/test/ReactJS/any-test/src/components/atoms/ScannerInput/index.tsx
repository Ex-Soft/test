import { useState, useRef, useEffect } from "react";
import { debounce } from "lodash";
import "./index.css";

export type ScannerInputProps = {
  codeLength?: number;
  wait?: number;
  onChange?: (value?: string) => void;
};

interface ScannerInputState {
  value?: string;
  lastValue?: string;
}

const checkCode = (value?: string, lastValue?: string, codeLength?: number) => {
  if (!codeLength) {
    return { isCode: false, code: undefined };
  }

  let code;
  const isCode =
    !!value &&
    value.length - (lastValue?.length || 0) === codeLength &&
    !/\D/.test((code = value.slice(-codeLength)));

  return { isCode, ...(isCode && { code }) };
};

const ScannerInput: React.FC<ScannerInputProps> = ({
  codeLength = undefined,
  wait = undefined,
  onChange = undefined,
}) => {
  console.log("ScannerInput() started");

  const [state, setState] = useState<ScannerInputState | null | undefined>({
    value: "",
    lastValue: "",
  });

  const delayCall = useRef(
    debounce((value?: string, state?: any, setState?: Function) => {
      console.log("delayCall(\"%s\") started { value: \"%s\", lastValue: \"%s\" }", value, state?.value, state?.lastValue);

      const { isCode, code } = checkCode(value, state?.lastValue, codeLength);

      if (isCode) {
        setState?.({ value: code, lastValue: code });
        console.log("code - %s { value: \"%s\", lastValue: \"%s\" }", code, state?.value, state?.lastValue);
      } else {
        setState?.({ lastValue: value });
        console.log("search - %s { value: \"%s\", lastValue: \"%s\" }", value, state?.value, state?.lastValue);
      }

      onChange?.(isCode ? code : value);

      console.log("delayCall(\"%s\") finished { value: \"%s\", lastValue: \"%s\" }", value, state?.value, state?.lastValue);
    }, wait)
  ).current;

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;

    setState({ value });
    console.log("before delayCall(\"%s\") { value: \"%s\", lastValue: \"%s\" }", value, state?.value, state?.lastValue);
    delayCall(value, state, setState);
    console.log("after delayCall(\"%s\") { value: \"%s\", lastValue: \"%s\" }", value, state?.value, state?.lastValue);
  };

  useEffect(() => {
    return () => {
      delayCall.cancel();
    };
  }, []);

  console.log("ScannerInput() finished");

  return (
    <input type="text" value={state?.value} onChange={(e) => handleChange(e)} />
  );
};

export default ScannerInput;
