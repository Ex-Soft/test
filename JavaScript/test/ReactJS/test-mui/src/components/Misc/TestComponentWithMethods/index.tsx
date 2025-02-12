import { forwardRef, useImperativeHandle, useRef, useState } from "react";
import { TextField, Button } from "@mui/material";
import "./index.css";

export interface ChildComponentProps {}

export interface ChildComponentRef {
  resetInput: () => void;
  focusInput: () => void;
  getValue: () => string;
}

export const TestComponentWithMethodsChild = forwardRef<
  ChildComponentRef,
  ChildComponentProps
>((_, ref) => {
  const [value, setValue] = useState("");
  const inputRef = useRef<HTMLInputElement>(null);

  useImperativeHandle(ref, () => ({
    resetInput: () => setValue(""),
    focusInput: () => inputRef.current?.focus?.(),
    getValue: () => value,
  }));

  return (
    <TextField
      value={value}
      onChange={({ target: { value } }) => setValue(value)}
      slotProps={{
        input: {
          inputRef: inputRef,
        },
      }}
    />
  );
});

export const TestComponentWithMethodsParent: React.FC = () => {
  const childRef = useRef<ChildComponentRef>(null);

  return (
    <div className="test-componentwithmethodsparent-container">
      <TestComponentWithMethodsChild ref={childRef} />
      <TextField />
      <Button onClick={() => childRef.current?.resetInput()}>Reset</Button>
      <Button onClick={() => childRef.current?.focusInput()}>Focus</Button>
      <Button
        onClick={() => {
          console.log(childRef.current?.getValue());
        }}
      >
        Value
      </Button>
    </div>
  );
};

export const TestComponentWithMethods: React.FC = () => {
  return (
    <div className="test-componentwithmethods-container">
      <TestComponentWithMethodsParent />
    </div>
  );
};
