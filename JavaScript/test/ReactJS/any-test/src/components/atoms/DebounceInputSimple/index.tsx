import { useState, useRef, ChangeEvent } from "react";
import { debounce } from "lodash";
import "./index.css";

export type DebounceInputSimpleProps = {
  onChange?: (value?: string) => void;
};

const delayCall = debounce((value?: string, onChange?: Function) => {
  console.log("delayCall() started value = %o", value);
  onChange?.(value);
  console.log("delayCall() finished value = %o", value);
}, 500);

const DebounceInputSimple: React.FC<DebounceInputSimpleProps> = ({
  onChange = undefined,
}) => {
  console.log("DebounceInputSimple() started");

  const [value, setValue] = useState<string | undefined>("");

  const handleInputChange = (
    e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const value = e.target.value;
    setValue((prev) => {
      console.log("DebounceInputSimple handleInputChange setState(%o => %o)", prev, value);
      return value;
    });
    delayCall(value, onChange);
  };

  return <input type="text" value={value} onChange={handleInputChange} />;
};

export default DebounceInputSimple;
