import { useEffect } from 'react';
import './index.css';

export type ChildClickableButtonProps = {
    onClick: () => void
};
   
const ChildClickableButton: React.FC<ChildClickableButtonProps> = ({ onClick }) => {
    useEffect(() => {
        console.log("ChildClickableButton.useEffect() (re-)render!!!");
    });

    useEffect(() => {
        console.log("ChildClickableButton.useEffect(, [])");
    }, []);

    return (
        <>
            <h2>Child Clickable Button</h2>
            <button onClick={onClick}>Click me!</button>
        </>
    );
};

export default ChildClickableButton;
