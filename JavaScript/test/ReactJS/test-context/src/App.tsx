import { useEffect } from "react";
import { Settings, useSettings } from "./index";
import "./App.css";

type ChildProps = {
  p1?: string;
  p2?: string;
  p3?: string;
  onClick?: (settings?: Settings) => void;
};

const Child: React.FC<ChildProps> = ({ p1, p2, p3, onClick }) => {
  return (
    <div>
      <p>{p1}</p>
      <p>{p2}</p>
      <p>{p3}</p>
      <input
        type="button"
        value="Click"
        onClick={() => {
          onClick?.({
            p1: p1?.toUpperCase(),
            p2: p2?.toUpperCase(),
            p3: p3?.toUpperCase(),
          });
        }}
      />
      <input
        type="button"
        value="Log (Child)"
        onClick={() => {
          console.log("Log (Child): {p1:%o, p2:%o, p3:%o}", p1, p2, p3);
        }}
      />
    </div>
  );
};

const Parent: React.FC = () => {
  const { settings } = useSettings();

  useEffect(() => {
    console.log("Parent() useEffect(() => {}, [settings]) %o", settings);
  }, [settings]);

  const onChildClick = (settings?: Settings) => {
    console.log(
      "onChildClick: {p1:%o, p2:%o, p3:%o}",
      settings?.p1,
      settings?.p2,
      settings?.p3
    );
  };

  return (
    <div>
      <input
        type="button"
        value="Log (Parent)"
        onClick={() => {
          console.log(
            "Log (Parent): {p1:%o, p2:%o, p3:%o}",
            settings?.p1,
            settings?.p2,
            settings?.p3
          );
        }}
      />
      <hr />
      <Child
        p1={settings?.p1}
        p2={settings?.p2}
        p3={settings?.p3}
        onClick={onChildClick}
      />
    </div>
  );
};

function App() {
  return <Parent />;
}

export default App;
