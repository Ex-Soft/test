import { useRef, useState, ChangeEvent } from "react";
import { Button, TextField } from "@mui/material";
import * as Yup from "yup";
import { cloneDeep, set } from "lodash";
import "./index.css";

const TestTextField: React.FC = () => {
  const requiredString = Yup.string().required();
  const [values, setValues] = useState<object>({});
  const [errors, setErrors] = useState<object>({});

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
    console.log(inputRef?.current);
    (inputRef?.current as any)?.focus?.();
  };

  const onTextFieldChange = (propertyName?: string, value?: string) => {
    if (!propertyName) {
      return;
    }

    setValue(propertyName, value);
    setError(propertyName, value);
  };

  const setValue = (propertyName?: string, newValue?: string) => {
    if (!propertyName) {
      return;
    }

    const oldValue = (values as { [key: string]: any })[propertyName];
    if (oldValue === newValue) {
      return;
    }

    const tmpValues = cloneDeep(values || {});
    set(tmpValues, propertyName, newValue);
    setValues(tmpValues);
  };

  const setError = (propertyName?: string, newValue?: string) => {
    if (!propertyName) {
      return;
    }

    const oldError = (errors as { [key: string]: any })[propertyName];
    const newError = !requiredString.isValidSync(newValue);
    if (oldError === newError) {
      return;
    }

    const tmpErrors = cloneDeep(errors || {});
    set(tmpErrors, propertyName, newError);
    setErrors(tmpErrors);
  };

  return (
    <div className="test-textfield-container">
      <div>
        <TextField inputRef={inputRef1} autoFocus />
        <TextField inputRef={inputRef2} />
        <TextField inputRef={inputRef3} />
        <Button onClick={() => handleFocusButtonClick(1)}>focus()</Button>
        <Button onClick={() => handleFocusButtonClick(2)}>focus()</Button>
        <Button onClick={() => handleFocusButtonClick(3)}>focus()</Button>
      </div>
      <hr />
      <div>
        <TextField
          slotProps={{
            htmlInput: { maxLength: 2 },
          }}
        />
        <TextField
          slotProps={{
            htmlInput: { pattern: "^(?:\\d{5}-\\d{4}|\\d{5})$" },
          }}
        />
      </div>
      <hr />
      <div>
        <TextField
          required
          label="Required"
          placeholder="Required"
          value={(values as { [key: string]: any })["textField1"]}
          onChange={(
            e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
          ) => {
            onTextFieldChange("textField1", e.target.value);
          }}
          error={(errors as { [key: string]: any })["textField1"]}
          helperText={
            (errors as { [key: string]: any })["textField1"]
              ? "This field is required"
              : null
          }
        />
      </div>
    </div>
  );
};

export default TestTextField;
