import { useEffect } from "react";
import "./index.css";

export type TestPropsChildProps = {
  data?: string;
};

const TestPropsChild: React.FC<TestPropsChildProps> = ({ data }) => {
  console.log('TestPropsChild({ data: "%o" })', data);

  useEffect(() => {
    // Runs after EVERY rendering
    console.log("TestPropsChild.useEffect(): This is mounted or updated.");
  });

  useEffect(() => {
    // Runs ONCE after initial rendering
    // Runs once, after mounting
    // Component did mount
    console.log(
      "TestPropsChild.useEffect(, []): This is mounted only not updated."
    );
  }, []);

  useEffect(() => {
    // Runs ONCE after initial rendering
    // and after every rendering ONLY IF `data` changes
    // Side-effect uses `data`
    // Component did update
    console.log(
      "TestPropsChild.useEffect(, [data]): This is mounted or data state updated."
    );
  }, [data]);

  useEffect(() => {
    return () => {
      console.log(
        "TestPropsChild.useEffect(return): This is unmounted or cleaning up everything after the previous side-effect."
      );
    };
  }, []);

  return (
    <div>
      <h1>Test Props Child</h1>
      <div>{!!data ? data : typeof data}</div>
    </div>
  );
};

export default TestPropsChild;
