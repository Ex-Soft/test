import { NavLink } from "react-router-dom";

const AdminNavBar: React.FC = () => {
  return (
    <nav>
      <ul>
        <li>
          <NavLink to="/">Home</NavLink>
        </li>
        <li>
          <NavLink
            to="products"
            style={({ isActive, isPending, isTransitioning }) => {
              return {
                fontWeight: isActive ? "bold" : "",
                color: isPending ? "red" : "black",
                viewTransitionName: isTransitioning ? "slide" : "",
              };
            }}
          >
            Products
          </NavLink>
        </li>
        <li>
          <NavLink
            to="dealers"
            style={({ isActive, isPending, isTransitioning }) => {
              return {
                fontWeight: isActive ? "bold" : "",
                color: isPending ? "red" : "black",
                viewTransitionName: isTransitioning ? "slide" : "",
              };
            }}
          >
            Dealers
          </NavLink>
        </li>
      </ul>
    </nav>
  );
};

export default AdminNavBar;
