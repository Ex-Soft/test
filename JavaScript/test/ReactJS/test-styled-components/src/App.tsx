// https://styled-components.com/docs/

import "./App.css";
import {
  CustomDiv,
  CustomButton,
  CustomButtonAsA,
  CustomTomatoButton,
  CustomTomatoButtonAsA,
  CustomButtonAsCustomReversedButton,
} from "./components";

function App() {
  return (
    <>
      <div className="container">
        <CustomDiv />
        <CustomDiv enabled={false} borderRadius="10px" />
        <CustomDiv
          enabled
          height="70px"
          width="150px"
          borderRadius="20px"
        />
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
        <button style={{
          cursor: "pointer"
        }}>button</button>
      </div>
    </>
  );
}

export default App;
