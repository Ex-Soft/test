import { useEffect } from "react";
import "./index.css";

const ComponentWithError: React.FC = () => {
  useEffect(() => {
    const timeout = setTimeout(() => {
      throw new Error("Error in the ComponentWithError");
    }, 2000);

    return () => clearTimeout(timeout);
  }, []);

  return (
    <div>
      <h1>Component with error</h1>
    </div>
  );
};

export default ComponentWithError;
