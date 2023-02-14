import { useEffect } from 'react';
import './index.css';

export type SpanProps = {
 text?: string;
};

const Span: React.FC<SpanProps> = ({text = undefined}) => {
    useEffect(() => {
        // Runs after EVERY rendering
        console.log(`useEffect(): This is mounted or updated (${text}).`);
    });

    useEffect(() => {
        // Runs ONCE after initial rendering
        // Runs once, after mounting
        // Component did mount
        console.log(`useEffect(, []): This is mounted only not updated (${text}).`);
    }, []);

    useEffect(() => {
        // Runs ONCE after initial rendering
        // and after every rendering ONLY IF `text` changes
        // Side-effect uses `text`
        // Component did update
        console.log(`useEffect(, [text]): This is mounted or data state updated (${text}).`);
    }, [text]);

    useEffect(() => {
        return () => {
            console.log(`useEffect(return): This is unmounted or cleaning up everything after the previous side-effect (${text}).`);
        };
    }, []);

    return (
        <span>
            {text}
        </span>
    )
};

export default Span;