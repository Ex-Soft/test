import styled from "styled-components";
import { StylesConfig } from "react-select";
import { IOption } from "../../data";

type IsMulti = true;

export const SelectStyle: StylesConfig<IOption> = {
  container: (base) => ({
    ...base,
    "&:not(:last-child)": {
      marginBottom: 16,
    },
  }),
  control: (base) => ({
    ...base,
    borderRadius: 0,
    minHeight: 75,
    paddingLeft: 20,
    paddingRight: 20,
  }),
  valueContainer: (base) => ({
    ...base,
    padding: 0,
  }),
  multiValueLabel: (base) => ({
    ...base,
    backgroundColor: "#21528C",
  }),
  placeholder: (base) => ({
    ...base,
    fontFamily: "PFDINText",
    fontSize: 16,
    letterSpacing: -0.2,
    fontWeight: "normal",
    color: "#9FA8B3",
  }),
};

export const MultiSelectStyle: StylesConfig<IOption, IsMulti> = {
  container: SelectStyle.container,
  control: SelectStyle.control,
  placeholder: SelectStyle.placeholder,
  multiValueLabel: (base) => ({
    ...base,
    color: "white",
    padding: 0,
    marginRight: 10,
  }),
  multiValueRemove: (base, state) => ({
    ...base,
    padding: 0,
    height: 20,
    width: 20,
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    borderRadius: "50%",
    transition: ".2s ease-in-out background-color",
    backgroundColor: state.isFocused ? "black" : "transparent",
    "&:hover": {
      backgroundColor: "black",
      color: "white",
      cursor: "pointer",
    },
  }),
  multiValue: (base) => ({
    ...base,
    backgroundColor: "#21528C",
    height: 26,
    display: "flex",
    alignItems: "center",
    justifyContent: "space-between",
    marginRight: 5,
    borderRadius: 18,
    color: "white",
    padding: "0 10px",
    "&:first-child": {
      backgroundColor: "red",
    },
  }),
  menu: (base, state) => ({
    ...base,
    display: !!state.options.length ? "block" : "none",
  }),
  menuList: (base, state) => ({
    ...base,
    display: !!state.options.length ? "block" : "none",
  }),
  noOptionsMessage: (base) => ({
    ...base,
    display: "none",
  }),
};
