import { TextField } from "@mui/material";
import "./index.css";

export const TestComponentWithMethodsChild: React.FC = () => {
  const test = () => {
    console.log("TestComponentWithMethodsChild.test()");
  };

  return <TextField />;
};

const getChild = () => {
  return <TestComponentWithMethodsChild />;
};

export const TestComponentWithMethodsParent: React.FC = () => {
  const child = getChild();

  console.log(child);

  return (
    <div className="test-componentwithmethodsparent-container">{child}</div>
  );
};

export const TestComponentWithMethods: React.FC = () => {
  return (
    <div className="test-componentwithmethods-container">
      <TestComponentWithMethodsParent />
    </div>
  );
};
