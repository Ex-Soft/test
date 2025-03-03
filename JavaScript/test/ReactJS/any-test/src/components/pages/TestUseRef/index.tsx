import { useState, useEffect, useRef } from "react";
import { TestCallChildMethodParent } from "../../atoms";
import "./index.css";

const TestUseRef: React.FC = () => {
  const [inputValue, setInputValue] = useState("");
  const count = useRef(0);

  useEffect(() => {
    count.current = count.current + 1;
  });

  const inputElement = useRef<HTMLInputElement>(null);
  const focusInput = () => {
    inputElement?.current?.focus();
  };

  const previousInputValue = useRef("");

  useEffect(() => {
    previousInputValue.current = inputValue;
  }, [inputValue]);

  return (
    <div>
      <h1>useRef</h1>
      <div>
        <input
          type="text"
          value={inputValue}
          onChange={(e) => setInputValue(e.target.value)}
        />
        <h1>Render Count: {count.current}</h1>
      </div>
      <div>
        <input
          type="text"
          ref={inputElement as React.LegacyRef<HTMLInputElement>}
        />
        <button onClick={focusInput}>Focus Input</button>
      </div>
      <div>
        <h2>Current Value: {inputValue}</h2>
        <h2>Previous Value: {previousInputValue.current}</h2>
      </div>
      <hr />
      <div>
        <TestCallChildMethodParent />
      </div>
    </div>
  );
};

export default TestUseRef;
