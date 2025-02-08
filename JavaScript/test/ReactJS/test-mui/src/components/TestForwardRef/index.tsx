import { useRef, forwardRef, useEffect, LegacyRef, useState } from "react";
import { Button, TextField, TextFieldProps } from "@mui/material";
import "./index.css";

type TestForwardRefChildProps = {} & TextFieldProps;

export const TestForwardRefChild = forwardRef<
  HTMLInputElement,
  TestForwardRefChildProps
>((props, ref) => {
  const [state, setState] = useState<string | null | undefined>();

  useEffect(() => {
    console.log("TestForwardRefChild useEffect(() => {}, [state = %o])", state);
  }, [state]);

  return (
    <TextField
      {...props}
      inputRef={ref}
      value={state}
      onChange={(e) => setState(e.target.value)}
    />
  );
});

export const TestForwardRefParent: React.FC = () => {
  const childRef = useRef<HTMLInputElement>(null);

  const handleFocusButtonClick = () => {
    (childRef?.current as any)?.focus();
  };

  const handleClearButtonClick = () => {
    (childRef.current as any).value = "";
  };

  return (
    <div className="test-forwardrefparent-container">
      <TestForwardRefChild ref={childRef as LegacyRef<HTMLInputElement>} />
      <Button onClick={handleFocusButtonClick}>focus()</Button>
      <Button onClick={handleClearButtonClick}>clear()</Button>
    </div>
  );
};

export const TestForwardRef: React.FC = () => {
  return (
    <div className="test-forwardref-container">
      <TestForwardRefParent />
    </div>
  );
};
