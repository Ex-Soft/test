import {
  DebounceInput,
  DebounceInputSimple,
  ScannerInput,
  CardNumberInput,
} from "../../atoms";
import "./index.css";

const CustomControls: React.FC = () => {
  return (
    <div>
      <h1>ScannerInput</h1>
      <ScannerInput
        codeLength={[4, 6, 8, 13]}
        wait={500}
        onChange={(o) => console.log(o)}
      />
      <hr />
      <h1>DebounceInput</h1>
      <DebounceInput
        onChange={(o) =>
          console.log("CustomControls DebounceInput onChange = %o", o)
        }
      />
      <hr />
      <h1>DebounceInputSimple</h1>
      <DebounceInputSimple
        onChange={(o) =>
          console.log("CustomControls DebounceInputSimple onChange = %o", o)
        }
      />
      <hr />
      <h1>CardNumberInput</h1>
      <CardNumberInput
        numberLength={[15,16]}
        onChange={(o) =>
          console.log("CustomControls CardNumberInput onChange = %o", o)
        }
      />
      <hr />
    </div>
  );
};

export default CustomControls;
