import { Routes, Route } from "react-router-dom";
import {
  Home,
  FullFeaturedCrudGrid,
  GridWithGridToolbar,
  NoMatch,
} from "./components";
import "./App.css";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />}>
        <Route path="fullfeaturedcrudgrid" element={<FullFeaturedCrudGrid />} />
        <Route path="gridwithgridtoolbar" element={<GridWithGridToolbar />} />
        <Route path="*" element={<NoMatch />} />
      </Route>
      <Route path="*" element={<NoMatch />} />
    </Routes>
  );
}

export default App;
