import { Stack } from "@mui/material";
import InfoIcon from "@mui/icons-material/Info";
import { FieldsetWithMUI } from "../../components";
import "./index.css";

const TestFieldsetWithMUI: React.FC = () => {
  return (
    <div>
      <h1>Test FieldsetWithMUI</h1>
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
    </div>
  );
};

export default TestFieldsetWithMUI;
