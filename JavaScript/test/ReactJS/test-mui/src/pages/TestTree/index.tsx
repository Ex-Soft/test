import { useState } from "react";
import { TreeDialog } from "../../components";
import "./index.css";

const TestTree: React.FC = () => {
  const [treeDialogOpen, setTreeDialogOpen] = useState(false);

  return (
    <div>
      <h1>Test Tree</h1>
      <input
        type="button"
        value="Tree"
        onClick={() => setTreeDialogOpen(true)}
      />
      <TreeDialog
        open={treeDialogOpen}
        title="Tree Dialog"
        data={[
          {
            id: "1",
            label: "Root",
            children: [
              { id: "11", label: "1.1" },
              {
                id: "12",
                label: "1.2",
                children: [
                  { id: "121", label: "1.2.1" },
                  { id: "122", label: "1.2.2" },
                  { id: "123", label: "1.2.3" },
                ],
              },
              { id: "13", label: "1.3" },
            ],
          },
        ]}
        onClose={() => setTreeDialogOpen(false)}
      />
      <hr />
    </div>
  );
};

export default TestTree;
