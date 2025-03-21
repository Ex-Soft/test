import { useRef, useState } from "react";
import {
  Button,
  IconButton,
  InputAdornment,
  MenuItem,
  Select,
  SelectChangeEvent,
  Box,
  FormControl,
  InputLabel,
} from "@mui/material";
import { Clear } from "@mui/icons-material";
import "./index.css";

const TestSelect: React.FC = () => {
  const [age1, setAge1] = useState("");
  const [age2, setAge2] = useState("");

  const inputRef1 = useRef<HTMLInputElement>(null);
  const inputRef2 = useRef<HTMLInputElement>(null);
  const inputRef3 = useRef<HTMLInputElement>(null);

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
    inputRef?.current?.focus?.();
  };

  const handleAge1Change = (event: SelectChangeEvent) => {
    setAge1(event.target.value as string);
  };

  const handleAge2Change = (event: SelectChangeEvent) => {
    setAge2(event.target.value as string);
  };

  const handleAge2Close = (event: React.SyntheticEvent<Element, Event>) => {
    console.log("onClose(%o)", event);
  };

  const handleAge2Blur = (event: React.FocusEvent<HTMLInputElement>) => {
    console.log("onBlur(%o)", event);
  };

  return (
    <div className="test-select-container">
      <Select
        label="Age"
        value={age1}
        onChange={handleAge1Change}
        inputRef={inputRef1}
        endAdornment={
          <InputAdornment sx={{ marginRight: "10px" }} position="end">
            <IconButton>
              <Clear />
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
        value={age1}
        onChange={handleAge1Change}
        inputRef={inputRef2}
        endAdornment={
          <InputAdornment sx={{ marginRight: "10px" }} position="end">
            <Clear />
          </InputAdornment>
        }
      >
        <MenuItem value={10}>Ten</MenuItem>
        <MenuItem value={20}>Twenty</MenuItem>
        <MenuItem value={30}>Thirty</MenuItem>
      </Select>
      <Select
        label="Age"
        value={age1}
        onChange={handleAge1Change}
        inputRef={inputRef3}
      >
        <MenuItem value={10}>Ten</MenuItem>
        <MenuItem value={20}>Twenty</MenuItem>
        <MenuItem value={30}>Thirty</MenuItem>
      </Select>
      <Button onClick={() => handleFocusButtonClick(1)}>focus()</Button>
      <Button onClick={() => handleFocusButtonClick(2)}>focus()</Button>
      <Button onClick={() => handleFocusButtonClick(3)}>focus()</Button>
      <hr />
      <Box sx={{ minWidth: 120 }}>
        <FormControl fullWidth>
          <InputLabel id="simple-select-label">Age</InputLabel>
          <Select
            labelId="simple-select-label"
            id="simple-select"
            value={age2}
            label="Age"
            onChange={handleAge2Change}
            onClose={handleAge2Close}
            onBlur={handleAge2Blur}
          >
            <MenuItem value={10}>Ten</MenuItem>
            <MenuItem value={20}>Twenty</MenuItem>
            <MenuItem value={30}>Thirty</MenuItem>
          </Select>
        </FormControl>
      </Box>
      <hr />
    </div>
  );
};

export default TestSelect;
