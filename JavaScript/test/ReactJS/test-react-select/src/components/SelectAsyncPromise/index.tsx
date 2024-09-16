import AsyncSelect from "react-select/async";
import { IColourOption, colourOptions } from "../../data";

const filterColors = (inputValue: string) => {
  return colourOptions.filter((i) =>
    i.label.toLowerCase().includes(inputValue.toLowerCase())
  );
};

const promiseOptions = (inputValue: string) =>
  new Promise<IColourOption[]>((resolve) => {
    setTimeout(() => {
      resolve(filterColors(inputValue));
    }, 1000);
  });

const SelectAsyncPromise: React.FC = () => {
  return (
    <div>
      <div>SelectAsyncPromise</div>
      <div>
        <AsyncSelect cacheOptions defaultOptions loadOptions={promiseOptions} />
      </div>
    </div>
  );
};

export default SelectAsyncPromise;
