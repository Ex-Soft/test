import { useState, useEffect, useRef } from 'react';
import './index.css';
import { CustomDropdownPicker } from '../../organisms';

const CustomDropdown: React.FC = () => {
    const selfRef = useRef<HTMLDivElement>(null)
    const buttonRef = useRef<HTMLButtonElement>(null)

    const [isOpen, setIsOpen] = useState<boolean>(false);

    useEffect(() => {
        function handleClickOutside(event: any) {
            console.log("%o %o %o", selfRef.current, buttonRef.current, event);

            if (selfRef.current && !selfRef.current.contains(event.target)) {
                setIsOpen(false);
            }
        }

        document.addEventListener("mousedown", handleClickOutside);

        return () => {
            document.removeEventListener("mousedown", handleClickOutside);
        };
    }, [selfRef]);

    const handleClick = (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        setIsOpen(isOpen => !isOpen)
    };

    return (
        <div ref={selfRef as React.LegacyRef<HTMLDivElement>}>
            <button
                ref={buttonRef as React.LegacyRef<HTMLButtonElement>}
                onClick={handleClick}
            >CustomDropdown</button>
            <CustomDropdownPicker isOpen={isOpen}></CustomDropdownPicker>
        </div>
    );
};

export default CustomDropdown;