// https://styled-components.com/docs/

import "./App.css";
import {
  CustomDiv,
  CustomButton,
  CustomButtonAsA,
  CustomTomatoButton,
  CustomTomatoButtonAsA,
  CustomButtonAsCustomReversedButton,
  ComponentWithChildren,
  TestPassStyles1,
  TestPassStyles2,
} from "./components";

function App() {
  return (
    <>
      <div className="container">
        <CustomDiv />
        <CustomDiv enabled={false} borderRadius="10px" />
        <CustomDiv enabled height="70px" width="150px" borderRadius="20px" />
      </div>
      <div className="container">
        <CustomButton>CustomButton</CustomButton>
        <CustomButtonAsA>CustomButtonAsA</CustomButtonAsA>
        <CustomTomatoButton disabled>CustomTomatoButton</CustomTomatoButton>
        <CustomTomatoButtonAsA>CustomTomatoButtonAsA</CustomTomatoButtonAsA>
        <CustomButtonAsCustomReversedButton>
          Custom Button with Normal Button styles
        </CustomButtonAsCustomReversedButton>
      </div>
      <div className="container">
        <button
          className="testButton"
          style={{
            cursor: "pointer",
          }}
        >
          Button
        </button>
      </div>
      <div className="container">
        <ComponentWithChildren />
      </div>
      <div className="container">
        <TestPassStyles1
          childrenContainerStyles={{
            placeSelf: "center",
            color: "white",
            backgroundColor: "red",
          }}
        >
          <div>Children</div>
        </TestPassStyles1>
      </div>
      <div className="container">
        <TestPassStyles2 alignSelf="end" justifySelf="end">
          <div>Children</div>
        </TestPassStyles2>
      </div>
    </>
  );
}

export default App;
