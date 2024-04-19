import { ScannerInput } from "../../atoms";
import "./index.css";

const CustomControls: React.FC = () => {
  return (
    <div>
      <h1>ScannerInput</h1>
      <ScannerInput
        codeLength={[6,8,13]}
        wait={500}
        onChange={(o) => console.log(o)}
      />
    </div>
  );
};

export default CustomControls;
