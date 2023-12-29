import { useEffect } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import {
  Navbar,
  Home,
  Profile,
  About,
  Protected,
  useIsLoggedIn,
} from "./components";
import "./App.css";

function App() {
  const { isLoggedIn, setIsLoggedIn } = useIsLoggedIn();

  console.log("App() isLoggedIn=%o", isLoggedIn);

  useEffect(() => {
    console.log("App() useEffect(() => {}) isLoggedIn=%o", isLoggedIn);
  });

  useEffect(() => {
    console.log("App() useEffect(() => {}, []) isLoggedIn=%o", isLoggedIn);
  }, []);

  useEffect(() => {
    console.log(
      "App() useEffect(() => {}, [isLoggedIn]) isLoggedIn=%o",
      isLoggedIn
    );
  }, [isLoggedIn]);

  return (
    <BrowserRouter>
      <Navbar />
      {isLoggedIn ? (
        <button
          onClick={() => {
            setIsLoggedIn(false);
          }}
        >
          Logout
        </button>
      ) : (
        <button
          onClick={() => {
            setIsLoggedIn(true);
          }}
        >
          Login
        </button>
      )}
      <Routes>
        <Route path="/" element={<Home />} />
        <Route
          path="/profile"
          element={
            <Protected isLoggedIn={isLoggedIn}>
              <Profile />
            </Protected>
          }
        />
        <Route path="/about" element={<About />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;

// yarn create react-app test-protected-route --template typescript
// yarn add react-router-dom
// https://hygraph.com/blog/routing-in-react
