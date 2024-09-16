import Select, { StylesConfig } from "react-select";
import chroma from "chroma-js";
import { IColourOption, colourOptions } from "../../data";

const MultiSelectCustomStyles: React.FC = () => {
  const colourStyles: StylesConfig<IColourOption, true> = {
    control: (styles) => ({ ...styles, backgroundColor: "white" }),
    option: (styles, { data, isDisabled, isFocused, isSelected }) => {
      const color = chroma(data.color);
      return {
        ...styles,
        backgroundColor: isDisabled
          ? undefined
          : isSelected
          ? data.color
          : isFocused
          ? color.alpha(0.1).css()
          : undefined,
        color: isDisabled
          ? "#ccc"
          : isSelected
          ? chroma.contrast(color, "white") > 2
            ? "white"
            : "black"
          : data.color,
        cursor: isDisabled ? "not-allowed" : "default",

        ":active": {
          ...styles[":active"],
          backgroundColor: !isDisabled
            ? isSelected
              ? data.color
              : color.alpha(0.3).css()
            : undefined,
        },
      };
    },
    multiValue: (styles, { data }) => {
      const color = chroma(data.color);
      return {
        ...styles,
        backgroundColor: color.alpha(0.1).css(),
        ":first-child": {
          backgroundColor: "red",
        },
      };
    },
    multiValueLabel: (styles, { data }) => ({
      ...styles,
      color: data.color,
    }),
    multiValueRemove: (styles, { data }) => ({
      ...styles,
      color: data.color,
      ":hover": {
        backgroundColor: data.color,
        color: "white",
      },
    }),
  };

  return (
    <div>
      <div>MultiSelectCustomStyles</div>
      <div>
        <Select
          closeMenuOnSelect={false}
          defaultValue={[colourOptions[0], colourOptions[1]]}
          isMulti
          options={colourOptions}
          styles={colourStyles}
        />
      </div>
    </div>
  );
};

export default MultiSelectCustomStyles;
