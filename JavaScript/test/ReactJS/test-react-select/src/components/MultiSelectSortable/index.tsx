import { MouseEventHandler, useState } from "react";
import Select, {
  components,
  MultiValueGenericProps,
  MultiValueProps,
  OnChangeValue,
  Props,
} from "react-select";
import {
  SortableContainer,
  SortableContainerProps,
  SortableElement,
  SortEndHandler,
  SortableHandle,
} from "react-sortable-hoc";
import { IOption, options } from "../../data";
import * as S from "./styles";

function arrayMove<T>(array: readonly T[], from: number, to: number) {
  const slicedArray = array.slice();
  slicedArray.splice(
    to < 0 ? array.length + to : to,
    0,
    slicedArray.splice(from, 1)[0]
  );
  return slicedArray;
}

const SortableMultiValue = SortableElement(
  (props: MultiValueProps<IOption>) => {
    // this prevents the menu from being opened/closed when the user clicks
    // on a value to begin dragging it. ideally, detecting a click (instead of
    // a drag) would still focus the control and toggle the menu, but that
    // requires some magic with refs that are out of scope for this example
    const onMouseDown: MouseEventHandler<HTMLDivElement> = (e) => {
      e.preventDefault();
      e.stopPropagation();
    };
    const innerProps = { ...props.innerProps, onMouseDown };
    return <components.MultiValue {...props} innerProps={innerProps} />;
  }
);

const SortableMultiValueLabel = SortableHandle(
  (props: MultiValueGenericProps) => <components.MultiValueLabel {...props} />
);

const SortableSelect = SortableContainer(Select) as React.ComponentClass<
  Props<IOption, true> & SortableContainerProps
>;

const MultiSelectSortable: React.FC = () => {
  const [selected, setSelected] = useState<readonly IOption[]>([
    options[4],
    options[5],
  ]);

  const onChange = (selectedOptions: OnChangeValue<IOption, true>) =>
    setSelected(selectedOptions);

  const onSortEnd: SortEndHandler = ({ oldIndex, newIndex }) => {
    const newValue = arrayMove(selected, oldIndex, newIndex);
    setSelected(newValue);
    console.log(
      "Values sorted:",
      newValue.map((i) => i.value)
    );
  };

  return (
    <div>
      <div>MultiSelectSortable</div>
      <div>
        <SortableSelect
          useDragHandle
          axis="xy"
          onSortEnd={onSortEnd}
          distance={4}
          getHelperDimensions={({ node }) => node.getBoundingClientRect()}
          isMulti
          options={options}
          value={selected}
          onChange={onChange}
          components={{
            // @ts-ignore We're failing to provide a required index prop to SortableElement
            MultiValue: SortableMultiValue,
            // @ts-ignore We're failing to provide a required index prop to SortableElement
            MultiValueLabel: SortableMultiValueLabel,
          }}
          closeMenuOnSelect={false}
          styles={S.MultiSelectStyle}
          helperClass="sortableHelper"
        />
      </div>
    </div>
  );
};

export default MultiSelectSortable;
