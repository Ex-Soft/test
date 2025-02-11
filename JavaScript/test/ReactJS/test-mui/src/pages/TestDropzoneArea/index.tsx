import { DropzoneArea } from "react-mui-dropzone";
import "./index.css";

const TestDropzoneArea: React.FC = () => {
  return (
    <div>
      <h1>Test DropzoneArea</h1>
      <hr />
      <DropzoneArea onChange={(files) => console.log("Files: %o", files)} />
      <hr />
    </div>
  );
};

export default TestDropzoneArea;
