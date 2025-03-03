import React, { useState, useRef } from "react";
import TestCallChildMethodChild, {
  TestCallChildMethodChildRef,
} from "../TestCallChildMethodChild";
import "./index.css";

export interface TestCallChildMethodParentProps {}

export const TestCallChildMethodParent: React.FC<
  TestCallChildMethodParentProps
> = () => {
  const [value, setValue] = useState("parent initial value");
  const childRef = useRef<TestCallChildMethodChildRef | null>(null);

  const doIt = (index?: number) => {
    if (!isNaN(index as number))
      childRefs.current[index as number].current?.doIt?.("parent.doIt()");
    else childRef?.current?.doIt?.("parent.doIt()");
  };

  const childRefs = useRef<
    React.RefObject<TestCallChildMethodChildRef | null>[]
  >([]);
  const childrenIds = [1, 2, 3];

  if (!childRefs.current.length)
    childRefs.current = childrenIds.map(() => React.createRef());

  return (
    <div>
      <div>
        <input
          type="text"
          value={value}
          onChange={({ target: { value } }) => setValue(value)}
        />
        <input type="button" value="DoIt!" onClick={() => doIt()} />
      </div>
      <TestCallChildMethodChild ref={childRef} value={value} />
      <hr />
      {childrenIds.map((id, index) => (
        <div>
          <div>
            <input type="button" value="DoIt!" onClick={() => doIt(index)} />
          </div>
          <TestCallChildMethodChild
            id={id}
            ref={childRefs.current[index]}
            value={value}
          />
        </div>
      ))}
    </div>
  );
};

export default TestCallChildMethodParent;
