import { useEffect } from "react";
import { Navigate } from "react-router-dom";

export type ProtectedProps = {
  isLoggedIn: boolean;
  children: any;
};

const Protected: React.FC<ProtectedProps> = ({ isLoggedIn, children }) => {
  console.log("Protected() isLoggedIn=%o", isLoggedIn);

  useEffect(() => {
    console.log("Protected() useEffect(() => {}) isLoggedIn=%o", isLoggedIn);
  });

  useEffect(() => {
    console.log(
      "Protected() useEffect(() => {}, []) isLoggedIn=%o",
      isLoggedIn
    );
  }, []);

  useEffect(() => {
    console.log(
      "Protected() useEffect(() => {}, [isLoggedIn]) isLoggedIn=%o",
      isLoggedIn
    );
  }, [isLoggedIn]);

  if (!isLoggedIn) {
    return <Navigate to="/" replace />;
  }

  return children;
};

export default Protected;
