import { Outlet } from "react-router-dom";
import Header from "../Header";
import "./index.css";

const Home: React.FC = () => {
    return (
        <div className="app">
        <Header />
        <Outlet />
      </div>
      );
  };
  
  export default Home;
