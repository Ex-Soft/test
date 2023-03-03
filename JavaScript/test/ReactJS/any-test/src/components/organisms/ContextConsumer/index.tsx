import { useContext } from "react";
import './index.css';

import { UserContext } from '../ContextProvider';

const ContextConsumer: React.FC = () => {
    const user = useContext(UserContext);

    return (
        <div>
            <h1>Context Consumer</h1>
            <p>{user}</p>
        </div>
    );
};

export default ContextConsumer;