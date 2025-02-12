import { useState } from "react";
import { Routes, Route, Link } from "react-router-dom";
import {
  Box,
  CssBaseline,
  AppBar,
  Drawer,
  List,
  ListItemButton,
  ListItemText,
  Toolbar,
  Typography,
  Collapse,
} from "@mui/material";
import ExpandLess from "@mui/icons-material/ExpandLess";
import ExpandMore from "@mui/icons-material/ExpandMore";
import TestTree from "../TestTree";
import TestDropzoneArea from "../TestDropzoneArea";
import TestFieldsetWithMUI from "../TestFieldsetWithMUI";
import NoMatch from "../NoMatch";
import {
  BasicLineChart,
  FullFeaturedCrudGrid,
  GridWithGridToolbar,
  TestComponentWithMethods,
  TestForwardRef,
  TestSelect,
  TestTextField,
  TestAccordion,
} from "../../components";
import "./index.css";

const drawerWidth = 240;

const Home: React.FC = () => {
  const [isOpenGrid, setIsOpenGrid] = useState(false);
  const [isOpenChart, setIsOpenChart] = useState(false);
  const [isOpenInput, setIsOpenInput] = useState(false);
  const [isOpenMisc, setIsOpenMisc] = useState(false);
  const [isOpenLayout, setIsOpenLayout] = useState(false);

  return (
    <Box sx={{ display: "flex" }}>
      <CssBaseline />
      {/* Header */}
      <AppBar
        position="fixed"
        sx={{ zIndex: (theme) => theme.zIndex.drawer + 1 }}
      >
        <Toolbar>
          <Typography variant="h6" noWrap component="div">
            Test MUI
          </Typography>
        </Toolbar>
      </AppBar>

      {/* Navigation */}
      <Drawer
        variant="permanent"
        sx={{
          width: drawerWidth,
          flexShrink: 0,
          [`& .MuiDrawer-paper`]: {
            width: drawerWidth,
            boxSizing: "border-box",
          },
        }}
      >
        <Toolbar />
        <Box sx={{ overflow: "auto" }}>
          <List>
            <ListItemButton onClick={() => setIsOpenGrid(!isOpenGrid)}>
              <ListItemText primary="Grid" />
              {isOpenGrid ? <ExpandLess /> : <ExpandMore />}
            </ListItemButton>
            <Collapse in={isOpenGrid} timeout="auto" unmountOnExit>
              <List component="div" disablePadding>
                <ListItemButton
                  component={Link}
                  to="/fullfeaturedcrudgrid"
                  sx={{ pl: 4 }}
                >
                  <ListItemText primary="FullFeaturedCrudGrid" />
                </ListItemButton>
                <ListItemButton
                  component={Link}
                  to="/gridwithgridtoolbar"
                  sx={{ pl: 4 }}
                >
                  <ListItemText primary="GridWithGridToolbar" />
                </ListItemButton>
              </List>
            </Collapse>
            <ListItemButton onClick={() => setIsOpenChart(!isOpenChart)}>
              <ListItemText primary="Chart" />
              {isOpenChart ? <ExpandLess /> : <ExpandMore />}
            </ListItemButton>
            <Collapse in={isOpenChart} timeout="auto" unmountOnExit>
              <List component="div" disablePadding>
                <ListItemButton
                  component={Link}
                  to="/basiclinechart"
                  sx={{ pl: 4 }}
                >
                  <ListItemText primary="BasicLineChart" />
                </ListItemButton>
              </List>
            </Collapse>
            <ListItemButton component={Link} to="/testtree">
              <ListItemText primary="Tree" />
            </ListItemButton>
            <ListItemButton component={Link} to="/testdropzonearea">
              <ListItemText primary="DropzoneArea" />
            </ListItemButton>
            <ListItemButton onClick={() => setIsOpenInput(!isOpenInput)}>
              <ListItemText primary="Input" />
              {isOpenInput ? <ExpandLess /> : <ExpandMore />}
            </ListItemButton>
            <Collapse in={isOpenInput} timeout="auto" unmountOnExit>
              <List component="div" disablePadding>
                <ListItemButton
                  component={Link}
                  to="/testtextfield"
                  sx={{ pl: 4 }}
                >
                  <ListItemText primary="TextField" />
                </ListItemButton>
                <ListItemButton
                  component={Link}
                  to="/testselect"
                  sx={{ pl: 4 }}
                >
                  <ListItemText primary="Select" />
                </ListItemButton>
              </List>
            </Collapse>
            <ListItemButton onClick={() => setIsOpenMisc(!isOpenMisc)}>
              <ListItemText primary="Misc" />
              {isOpenMisc ? <ExpandLess /> : <ExpandMore />}
            </ListItemButton>
            <Collapse in={isOpenMisc} timeout="auto" unmountOnExit>
              <List component="div" disablePadding>
                <ListItemButton
                  component={Link}
                  to="/testforwardref"
                  sx={{ pl: 4 }}
                >
                  <ListItemText primary="forwardRef" />
                </ListItemButton>
                <ListItemButton
                  component={Link}
                  to="/testcomponentwithmethods"
                  sx={{ pl: 4 }}
                >
                  <ListItemText primary="Component with methods" />
                </ListItemButton>
                <ListItemButton
                  component={Link}
                  to="/testfieldsetwithmui"
                  sx={{ pl: 4 }}
                >
                  <ListItemText primary="Fieldset with MUI" />
                </ListItemButton>
              </List>
            </Collapse>
            <ListItemButton onClick={() => setIsOpenLayout(!isOpenLayout)}>
              <ListItemText primary="Layout" />
              {isOpenLayout ? <ExpandLess /> : <ExpandMore />}
            </ListItemButton>
            <Collapse in={isOpenLayout} timeout="auto" unmountOnExit>
              <List component="div" disablePadding>
                <ListItemButton
                  component={Link}
                  to="/testaccordion"
                  sx={{ pl: 4 }}
                >
                  <ListItemText primary="Accordion" />
                </ListItemButton>
              </List>
            </Collapse>
          </List>
        </Box>
      </Drawer>

      {/* Main Content */}
      <Box
        component="main"
        sx={{ flexGrow: 1, p: 3, ml: `${drawerWidth}px`, mt: 8 }}
      >
        <Routes>
          <Route
            path="/"
            element={
              <div style={{ textAlign: "center" }}>
                <h1>Test MUI</h1>
              </div>
            }
          />
          <Route
            path="/fullfeaturedcrudgrid"
            element={<FullFeaturedCrudGrid />}
          />
          <Route
            path="/gridwithgridtoolbar"
            element={<GridWithGridToolbar />}
          />
          <Route path="/basiclinechart" element={<BasicLineChart />} />
          <Route path="/testtree" element={<TestTree />} />
          <Route path="/testdropzonearea" element={<TestDropzoneArea />} />
          <Route path="/testtextfield" element={<TestTextField />} />
          <Route path="/testselect" element={<TestSelect />} />
          <Route path="/testforwardref" element={<TestForwardRef />} />
          <Route
            path="/testfieldsetwithmui"
            element={<TestFieldsetWithMUI />}
          />
          <Route
            path="/testcomponentwithmethods"
            element={<TestComponentWithMethods />}
          />
          <Route path="/testaccordion" element={<TestAccordion />} />
          <Route path="*" element={<NoMatch />} />
        </Routes>
      </Box>
    </Box>
  );
};

export default Home;
