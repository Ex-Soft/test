import { useState } from "react";
import { Stack } from "@mui/material";
import InfoIcon from "@mui/icons-material/Info";
import { FieldsetWithMUI, TreeDialog } from "../../components";
import "./index.css";

const TestTree: React.FC = () => {
  const [treeDialogOpen, setTreeDialogOpen] = useState(false);

  return (
    <div>
      <h1>Test Tree</h1>
      <hr />
      <FieldsetWithMUI
        title={
          <Stack direction="row" alignItems="center" gap={1}>
            <InfoIcon />
            User Information
          </Stack>
        }
        color="grey.400"
        titleSize="1.2rem"
        borderWidth={2}
        borderRadius={3}
        sx={{
          borderStyle: "dashed",
          padding: 3,
          "& legend": {
            backgroundColor: "secondary.main",
            color: "grey.200",
            padding: "0 8px",
            borderRadius: "4px",
          },
          backgroundColor: "grey.100",
        }}
      >
        <label>
          Username: <input type="text" name="username" />
        </label>
        <label>
          Password: <input type="password" name="password" />
        </label>
      </FieldsetWithMUI>
      <hr />
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
