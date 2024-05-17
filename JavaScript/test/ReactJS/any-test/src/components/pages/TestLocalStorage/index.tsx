import { usePersistedState, usePersistedSubState } from "../../../hooks";
import "./index.css";

const TestLocalStorage: React.FC = () => {
  const [localStorageValue, setLocalStorageValue] = usePersistedState<
    string | null | undefined
  >("localStorageValue", null);
  const [localStorageValueWithSubValues, setLocalStorageValueWithSubValues] = usePersistedSubState<
  string | null | undefined
>("localStorageValueWithSubValues", "subKey", null);

  console.log("TestLocalStorage");

  const handleGetButtonClick = () => {
    console.log("localStorageValue=%o localStorageValueWithSubValues=%o", localStorageValue, localStorageValueWithSubValues);
  };

  const handleSetButtonClick = () => {
    setLocalStorageValue("smthValue");
    setLocalStorageValueWithSubValues("smthSubValue");
  };

  const handleGetItemButtonClick = () => {
    console.log("localStorage.localStorageValue=%o localStorage.localStorageValueWithSubValues=%o", localStorage.getItem("localStorageValue"), localStorage.getItem("localStorageValueWithSubValues"));
  };

  const handleSetItemStringButtonClick = () => {
    localStorage.setItem("localStorageValue", "stringValue");
    localStorage.setItem("localStorageValueWithSubValues", "stringValue");
  };

  return (
    <div>
      <h1>TestLocalStorage</h1>
      <hr />
      <input type="button" value="Get" onClick={handleGetButtonClick} />
      <input type="button" value="Set" onClick={handleSetButtonClick} />
      <hr/>
      <input type="button" value="localStorage.GetItem()" onClick={handleGetItemButtonClick} />
      <input type="button" value="localStorage.SetItem() (string)" onClick={handleSetItemStringButtonClick} />
    </div>
  );
};

export default TestLocalStorage;
