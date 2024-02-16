import { ChangeEvent, useState } from "react";
import {
  Box,
  FormControl,
  InputLabel,
  Select,
  SelectChangeEvent,
  MenuItem,
  TextField,
} from "@mui/material";
import * as Yup from "yup";
import { cloneDeep, set } from "lodash";
import { DropzoneArea } from "react-mui-dropzone";
import { TreeDialog } from "../../organisms";
import "./index.css";

const TestMUI: React.FC = () => {
  const [age, setAge] = useState("");
  const [treeDialogOpen, setTreeDialogOpen] = useState(false);
  const requiredString = Yup.string().required();
  const [values, setValues] = useState<object>({});
  const [errors, setErrors] = useState<object>({});

  const handleChange = (event: SelectChangeEvent) => {
    setAge(event.target.value as string);
  };

  const handleClose = (event: React.SyntheticEvent<Element, Event>) => {
    console.log("onClose(%o)", event);
  };

  const handleBlur = (event: React.FocusEvent<HTMLInputElement>) => {
    console.log("onBlur(%o)", event);
  };

  const handleBtnTreeClick = (event: React.MouseEvent<HTMLInputElement>) => {
    setTreeDialogOpen(true);
  };

  const handleTreeDialogClose = () => {
    setTreeDialogOpen(false);
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
    <div>
      <h1>Test MUI</h1>
      <hr />
      <TextField
        required
        label="Required"
        placeholder="Required"
        value={(values as { [key: string]: any })["textField1"]}
        onChange={(e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
          onTextFieldChange("textField1", e.target.value);
        }}
        error={(errors as { [key: string]: any })["textField1"]}
        helperText={
          (errors as { [key: string]: any })["textField1"]
            ? "This field is required"
            : null
        }
      />
      <hr />
      <input type="button" value="Tree" onClick={handleBtnTreeClick} />
      <TreeDialog
        open={treeDialogOpen}
        title="Tree Dialog"
        data={{
          id: "1",
          name: "Root",
          children: [
            { id: "11", name: "1.1" },
            {
              id: "12",
              name: "1.2",
              children: [
                { id: "121", name: "1.2.1" },
                { id: "122", name: "1.2.2" },
                { id: "123", name: "1.2.3" },
              ],
            },
            { id: "13", name: "1.3" },
          ],
        }}
        onClose={handleTreeDialogClose}
      />
      <hr />
      <Box sx={{ minWidth: 120 }}>
        <FormControl fullWidth>
          <InputLabel id="simple-select-label">Age</InputLabel>
          <Select
            labelId="simple-select-label"
            id="simple-select"
            value={age}
            label="Age"
            onChange={handleChange}
            onClose={handleClose}
            onBlur={handleBlur}
          >
            <MenuItem value={10}>Ten</MenuItem>
            <MenuItem value={20}>Twenty</MenuItem>
            <MenuItem value={30}>Thirty</MenuItem>
          </Select>
        </FormControl>
      </Box>
      <hr />
      <DropzoneArea onChange={(files) => console.log("Files: %o", files)} />
      <hr />
    </div>
  );
};

export default TestMUI;
