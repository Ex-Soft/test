import ContextProvider from "../../organisms/ContextProvider";
import './index.css';

const TestUseContext: React.FC = () => {
    return (
        <div>
            <h1>useContext</h1>
            <div>
                <ContextProvider />
            </div>
        </div>
    );
};

export default TestUseContext;