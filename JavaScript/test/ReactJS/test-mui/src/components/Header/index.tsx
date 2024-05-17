import { NavLink } from "react-router-dom";
import "./index.css";

const Header: React.FC = () => {
  return (
    <div className="header-container">
      <div>
        <NavLink to="fullfeaturedcrudgrid">FullFeaturedCrudGrid</NavLink>
      </div>
      <div>
        <NavLink to="gridwithgridtoolbar">GridWithGridToolbar</NavLink>
      </div>
      <div>
        <NavLink to="testtextfield">TestTextField</NavLink>
      </div>
    </div>
  );
};

export default Header;
