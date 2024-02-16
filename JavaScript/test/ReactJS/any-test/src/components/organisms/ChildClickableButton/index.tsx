import { useEffect, useRef } from "react";
import "./index.css";

export type ChildClickableButtonProps = {
  onClick: () => void;
};

const ChildClickableButton: React.FC<ChildClickableButtonProps> = ({
  onClick,
}) => {
  useEffect(() => {
    console.log("ChildClickableButton.useEffect(() => {}) (re-)render!!!");
  });

  useEffect(() => {
    console.log("ChildClickableButton.useEffect(() => {}, [])");
  }, []);

  const constCall = useRef(() => {
    onClick?.();
  }).current;

  return (
    <div className="child-clickable-button-container">
      <h5>Child Clickable Button</h5>
      <button onClick={onClick}>onClick</button>
      <button onClick={constCall}>useRef(onClick)</button>
    </div>
  );
};

export default ChildClickableButton;
