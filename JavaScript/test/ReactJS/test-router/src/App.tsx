import { Route, Routes } from "react-router-dom";
import { Home, Admin, Products, Dealers, NoMatch } from "./components";
import "./App.css";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/admin" element={<Admin />}>
        <Route path="products" element={<Products />} />
        <Route path="dealers" element={<Dealers />} />
      </Route>
      <Route path="*" element={<NoMatch />} />
    </Routes>
  );
}

export default App;
