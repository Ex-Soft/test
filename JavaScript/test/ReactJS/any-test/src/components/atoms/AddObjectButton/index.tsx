import { useEffect } from 'react';
import './index.css';

export type AddObjectButtonProps = {
    data?: any[];
    stateChanger?: (data: any[]) => void;
};

const AddObjectButton: React.FC<AddObjectButtonProps> = ({
    data = undefined,
    stateChanger = undefined
}) => {
    useEffect(() => {
        // Runs after EVERY rendering
        console.log('useEffect(): This is mounted or updated.');
    });

    useEffect(() => {
        // Runs ONCE after initial rendering
        // Runs once, after mounting
        // Component did mount
        console.log('useEffect(, []): This is mounted only not updated.');
    }, []);

    useEffect(() => {
        // Runs ONCE after initial rendering
        // and after every rendering ONLY IF `data` changes
        // Side-effect uses `data`
        // Component did update
        console.log('useEffect(, [data]): This is mounted or data state updated.');
    }, [data]);

    useEffect(() => {
        return () => {
            console.log('useEffect(return): This is unmounted or cleaning up everything after the previous side-effect.');
        };
    }, []);

    const handleClick = () => {
        if (!Array.isArray(data))
            return;
        
        if (stateChanger)
            stateChanger(data.concat([{ id: data.length + 1, value: `Value# ${data.length + 1}` }]));
    };

    return (
        <input
            type='button'
            value='Add'
            onClick={handleClick}
        />
    );
};

export default AddObjectButton;