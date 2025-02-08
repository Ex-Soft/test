import { Routes, Route } from "react-router-dom";
import {
  Home,
  FullFeaturedCrudGrid,
  GridWithGridToolbar,
  TestTextField,
  TestSelect,
  NoMatch,
  TestForwardRef,
  TestComponentWithMethods,
  BasicLineChart,
} from "./components";
import "./App.css";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />}>
        <Route path="fullfeaturedcrudgrid" element={<FullFeaturedCrudGrid />} />
        <Route path="gridwithgridtoolbar" element={<GridWithGridToolbar />} />
        <Route path="basiclinechart" element={<BasicLineChart />} />
        <Route path="testtextfield" element={<TestTextField />} />
        <Route path="testselect" element={<TestSelect />} />
        <Route path="testforwardref" element={<TestForwardRef />} />
        <Route
          path="testcomponentwithmethods"
          element={<TestComponentWithMethods />}
        />
        <Route path="*" element={<NoMatch />} />
      </Route>
      <Route path="*" element={<NoMatch />} />
    </Routes>
  );
}

export default App;

// yarn create react-app test-mui --template typescript
// yarn upgrade
// yarn install --check-files
