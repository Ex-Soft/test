import { forwardRef, useImperativeHandle, useState } from "react";
import "./index.css";

export interface TestCallChildMethodChildProps {
  id?: number;
  value?: string;
}

export interface TestCallChildMethodChildRef {
  doIt: (value?: string) => void;
}

export const TestCallChildMethodChild = forwardRef<
  TestCallChildMethodChildRef,
  TestCallChildMethodChildProps
>(({ id, value: _value }, ref) => {
  const [value, setValue] = useState<string | undefined>(
    !isNaN(id as number) || !!_value
      ? `${!isNaN(id as number) ? id : ""}${
          !isNaN(id as number) && !!_value ? " " : ""
        }${!!_value ? _value : ""}`
      : undefined
  );

  const doIt = (value?: string) =>
    setValue(
      !isNaN(id as number) || !!value
        ? `${!isNaN(id as number) ? id : ""}${
            !isNaN(id as number) && !!value ? " " : ""
          }${!!value ? value : ""}`
        : undefined
    );

  useImperativeHandle(ref, () => ({
    doIt: doIt,
  }));

  return <div>{value}</div>;
});

export default TestCallChildMethodChild;
