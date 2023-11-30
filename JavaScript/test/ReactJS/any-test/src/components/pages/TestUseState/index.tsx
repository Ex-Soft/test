import { useState } from "react";
import "./index.css";

const TestUseState: React.FC = () => {
  const [victim, setVictim] = useState<{ p1: number, p2: number}>({ p1: 0, p2: 0 });

  const callSetVictim = () => {
    console.log("callSetVictim()");
    setVictim(v => {
        return { ...v, p2: v.p2 + 1 };
    });
  };

  return (
    <div>
      <h1>useState</h1>
      <div>
        <p>{`{p1: ${victim.p1}, p2: ${victim.p2}}`}</p>
      </div>
      <div>
        <input
          type="button"
          value="call setVictim({p1, p2++})"
          onClick={() => callSetVictim()}
        />
      </div>
    </div>
  );
};

export default TestUseState;
