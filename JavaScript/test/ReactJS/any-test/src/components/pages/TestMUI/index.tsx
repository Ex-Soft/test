import { useState } from 'react';
import Box from '@mui/material/Box';
import FormControl from '@mui/material/FormControl';
import InputLabel from '@mui/material/InputLabel';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import { TreeDialog } from '../../organisms';
import './index.css';
import { DropzoneArea } from 'react-mui-dropzone';

const TestMUI: React.FC = () => {
    const [age, setAge] = useState('');
    const [treeDialogOpen, setTreeDialogOpen] = useState(false);

    const handleChange = (event: SelectChangeEvent) => {
        setAge(event.target.value as string);
    };

    const handleClose = (event: React.SyntheticEvent<Element, Event>) => {
        console.log("onClose(%o)", event);
    };

    const handleBlur = (event: React.FocusEvent<HTMLInputElement>) => {
        console.log("onBlur(%o)", event);
    }

    const handleBtnTreeClick = (event: React.MouseEvent<HTMLInputElement>) => {
        setTreeDialogOpen(true)
    }

    const handleTreeDialogClose = () => {
        setTreeDialogOpen(false)
    }

    return (
        <div>
            <h1>Test MUI</h1>
            <hr/>
                <input type="button" value="Tree" onClick={handleBtnTreeClick} />
                <TreeDialog
                    open={treeDialogOpen}
                    title="Tree Dialog"
                    data={({id: "1", name: "Root", children: [{id:"11", name: "1.1"}, {id:"12", name: "1.2", children: [{id: "121", name: "1.2.1"}, {id: "122", name: "1.2.2"},{id: "123", name: "1.2.3"}]}, {id:"13", name: "1.3"}]})}
                    onClose={handleTreeDialogClose}
                />
            <hr/>
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
            <hr/>
                <DropzoneArea onChange={(files) => console.log("Files: %o", files)} />
            <hr/>
        </div>
    )
}

export default TestMUI;