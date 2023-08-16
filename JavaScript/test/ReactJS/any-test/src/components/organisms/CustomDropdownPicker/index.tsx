import './index.css';

export type CustomDropdownPickerProps = {
    isOpen?: boolean;
};
   
const CustomDropdownPicker: React.FC<CustomDropdownPickerProps> = ({isOpen = false}) => {
    return (
        <div hidden={!isOpen}>
            {
                [1, 2, 3].map((item, index) => (
                    <p key={index}>{item}</p>
                ))
            }
        </div>
    );
}

export default CustomDropdownPicker;