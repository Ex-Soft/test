import { useState } from "react";
import TestPropsChild from "../TestPropsChild";
import "./index.css";

const TestPropsParent: React.FC = () => {
  const [data, setData] = useState<string | undefined>();

  return (
    <div>
      <h1>Test Props Parent</h1>
      <div>
        <input
          type="button"
          value="Set"
          onClick={() => setData("from parent")}
        />
        <input type="button" value="Reset" onClick={() => setData(undefined)} />
      </div>
      <TestPropsChild data={data} />
    </div>
  );
};

export default TestPropsParent;
