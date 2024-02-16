import { useEffect, useState } from "react";
import { useTestState } from "../../../hooks";
import "./index.css";

const TestUseState: React.FC = () => {
  const [victim, setVictim] = useState<{ p1: number; p2: number }>({
    p1: 0,
    p2: 0,
  });

  const [state1, setState1] = useState("Initial value state# 1");
  const [state2, setState2] = useState("Initial value state# 2");
  const [state3, setState3] = useState("Initial value state# 3");

  const { data, setData } = useTestState({
    p1: "p1 Initial value",
    p2: "p2 Initial value",
    p3: "p3 Initial value",
  });

  console.log(
    "TestUseState(): state1=%o state2=%o state3=%o {p1:%o, p2:%o, p3:%o}",
    state1,
    state2,
    state3,
    data.p1,
    data.p2,
    data.p3
  );

  useEffect(() => {
    console.log("useEffect(() => {})");
  });

  useEffect(() => {
    console.log("useEffect(() => {}, [])");
  }, []);

  useEffect(() => {
    console.log(
      "useEffect(() => { data = {p1:%o, p2:%o, p3:%o} }, [data])",
      data.p1,
      data.p2,
      data.p3
    );
  }, [data]);

  const callSetVictim = () => {
    console.log("callSetVictim()");
    setVictim((v) => {
      return { ...v, p2: v.p2 + 1 };
    });
  };

  const callSetStateWOPromise = () => {
    setState1("Updated value state# 1 (w/o Promise)");
    setState2("Updated value state# 2 (w/o Promise)");
    setState3("Updated value state# 3 (w/o Promise)");
  };

  const callSetStateWithPromise = () => {
    Promise.resolve().then(() => {
      setState1("Updated value state# 1 (with Promise)");
      setState2("Updated value state# 2 (with Promise)");
      setState3("Updated value state# 3 (with Promise)");
    });
  };

  const callSetData = () => {
    setData((_data: any) => {
      return { ..._data, p2: "p2 New value", p3: "p3 New value" };
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
      <div>
        <input
          type="button"
          value="setState w/o Promise"
          onClick={() => callSetStateWOPromise()}
        />
        <input
          type="button"
          value="setState with Promise"
          onClick={() => callSetStateWithPromise()}
        />
        <input type="button" value="setData()" onClick={() => callSetData()} />
        <input
          type="button"
          value="log()"
          onClick={() =>
            console.log(
              "state1=%o state2=%o state3=%o {p1:%o, p2:%o, p3:%o}",
              state1,
              state2,
              state3,
              data.p1,
              data.p2,
              data.p3
            )
          }
        />
      </div>
    </div>
  );
};

export default TestUseState;
