import { useRef } from "react";
import { Button, TextField } from "@mui/material";
import "./index.css";

const TestTextField: React.FC = () => {
  const inputRef1 = useRef(null);
  const inputRef2 = useRef(null);
  const inputRef3 = useRef(null);

  const handleFocusButtonClick = (n: number) => {
    let inputRef;
    switch (n) {
      case 1:
        inputRef = inputRef1;
        break;
      case 2:
        inputRef = inputRef2;
        break;
      case 3:
        inputRef = inputRef3;
        break;
      default:
        inputRef = inputRef1;
    }

    (inputRef?.current as any)?.focus?.();
  };

  return (
    <div className="test-textfield-container">
      <TextField inputRef={inputRef1} autoFocus />
      <TextField inputRef={inputRef2} />
      <TextField inputRef={inputRef3} />
      <Button onClick={() => handleFocusButtonClick(1)}>focus()</Button>
      <Button onClick={() => handleFocusButtonClick(2)}>focus()</Button>
      <Button onClick={() => handleFocusButtonClick(3)}>focus()</Button>
    </div>
  );
};

export default TestTextField;
