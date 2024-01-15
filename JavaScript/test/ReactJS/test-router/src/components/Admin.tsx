import { Outlet } from "react-router-dom";
import AdminNavBar from "./AdminNavBar";

const Admin: React.FC = () => {
  return (
    <div>
      <h1>Admin</h1>
      <AdminNavBar />
      <Outlet />
    </div>
  );
};

export default Admin;
