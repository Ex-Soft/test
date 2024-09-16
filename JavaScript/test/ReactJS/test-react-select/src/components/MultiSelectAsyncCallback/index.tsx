import AsyncSelect from "react-select/async";
import { IColourOption, colourOptions } from "../../data";

const filterColors = (inputValue: string) => {
  return colourOptions.filter((i) =>
    i.label.toLowerCase().includes(inputValue.toLowerCase())
  );
};

const loadOptions = (
  inputValue: string,
  callback: (options: IColourOption[]) => void
) => {
  setTimeout(() => {
    callback(filterColors(inputValue));
  }, 1000);
};

const MultiSelectAsyncCallback: React.FC = () => {
  return (
    <div>
      <div>MultiSelectAsyncCallback</div>
      <div>
        <AsyncSelect
          isMulti
          cacheOptions
          defaultOptions
          loadOptions={loadOptions}
        />
      </div>
    </div>
  );
};

export default MultiSelectAsyncCallback;
