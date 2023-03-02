import './index.css';
import { Span } from '../../atoms';

const TestUseEffect: React.FC = () => {
    return (
        <div>
            <h1>useEffect</h1>
            <div>
                <p>
                    <Span text='Span# 1' /><Span text='Span# 1' /><Span text='Span# 2' />
                </p>
            </div>
        </div>
    );
};

export default TestUseEffect;