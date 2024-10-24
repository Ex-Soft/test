import { Routes, Route } from "react-router-dom";
import {
  Home,
  FullFeaturedCrudGrid,
  GridWithGridToolbar,
  TestTextField,
  NoMatch,
  TestForwardRef,
  TestComponentWithMethods,
} from "./components";
import "./App.css";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />}>
        <Route path="fullfeaturedcrudgrid" element={<FullFeaturedCrudGrid />} />
        <Route path="gridwithgridtoolbar" element={<GridWithGridToolbar />} />
        <Route path="gridwithgridtoolbar" element={<GridWithGridToolbar />} />
        <Route path="testtextfield" element={<TestTextField />} />
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
