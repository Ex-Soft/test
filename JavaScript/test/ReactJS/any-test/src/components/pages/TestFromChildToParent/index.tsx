import { useState } from "react";
import { Button } from "../../atoms";
import { Table } from "../../organisms";
import "./index.css";

const TestFromChildToParent: React.FC = () => {
  const [data, setData] = useState([
    { id: 1, value: "Value# 1" },
    { id: 2, value: "Value# 2" },
  ]);

  return (
    <div>
      <h1>From Child To Parent</h1>
      <div>
        <Button data={data} stateChanger={setData} />
        <Table data={data} />
      </div>
    </div>
  );
};

export default TestFromChildToParent;
