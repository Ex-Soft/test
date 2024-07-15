import { useMemo, useState, useRef, useEffect, ChangeEvent } from "react";
import { debounce } from "lodash";
import "./index.css";

export type DebounceInputProps = {
  onChange?: (value?: string) => void;
};

const DebounceInput: React.FC<DebounceInputProps> = ({
  onChange = undefined,
}) => {
  console.log("DebounceInput() started");

  const [value, setValue] = useState<string | undefined>("");

  const sendRequest = () => {
    console.log("DebounceInput sendRequest = %o", value);
    onChange?.(value);
  };

  const ref = useRef(sendRequest);

  useEffect(() => {
    ref.current = sendRequest;
  }, [value]);

  const debouncedCallback = useMemo(() => {
    const func = () => {
      ref.current?.();
    };
    return debounce(func, 1000);
  }, []);

  const handleInputChange = (
    e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const value = e.target.value;
    setValue(value);
    debouncedCallback();
  };

  return <input type="text" value={value} onChange={handleInputChange} />;
};

export default DebounceInput;
