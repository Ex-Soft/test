import { useRef, useState } from "react";
import {
  Button,
  IconButton,
  InputAdornment,
  MenuItem,
  Select,
  SelectChangeEvent,
} from "@mui/material";
import ClearIcon from "@mui/icons-material/Clear";
import "./index.css";

const TestSelect: React.FC = () => {
  const [age, setAge] = useState("");

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

  const handleChange = (event: SelectChangeEvent) => {
    setAge(event.target.value as string);
  };

  return (
    <div className="test-select-container">
      <Select
        label="Age"
        value={age}
        onChange={handleChange}
        inputRef={inputRef1}
        endAdornment={
          <InputAdornment sx={{ marginRight: "10px" }} position="end">
            <IconButton>
              <ClearIcon />
            </IconButton>
          </InputAdornment>
        }
        autoFocus
      >
        <MenuItem value={10}>Ten</MenuItem>
        <MenuItem value={20}>Twenty</MenuItem>
        <MenuItem value={30}>Thirty</MenuItem>
      </Select>
      <Select
        label="Age"
        value={age}
        onChange={handleChange}
        inputRef={inputRef2}
        endAdornment={
          <InputAdornment sx={{ marginRight: "10px" }} position="end">
            <ClearIcon />
          </InputAdornment>
        }
      >
        <MenuItem value={10}>Ten</MenuItem>
        <MenuItem value={20}>Twenty</MenuItem>
        <MenuItem value={30}>Thirty</MenuItem>
      </Select>
      <Select
        label="Age"
        value={age}
        onChange={handleChange}
        inputRef={inputRef3}
      >
        <MenuItem value={10}>Ten</MenuItem>
        <MenuItem value={20}>Twenty</MenuItem>
        <MenuItem value={30}>Thirty</MenuItem>
      </Select>
      <Button onClick={() => handleFocusButtonClick(1)}>focus()</Button>
      <Button onClick={() => handleFocusButtonClick(2)}>focus()</Button>
      <Button onClick={() => handleFocusButtonClick(3)}>focus()</Button>
    </div>
  );
};

export default TestSelect;
