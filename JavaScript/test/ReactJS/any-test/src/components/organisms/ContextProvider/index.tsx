import { useState, createContext } from "react";
import './index.css';
import ContextConsumer from "../ContextConsumer";

export const UserContext = createContext('Unknown');

const ContextProvider: React.FC = () => {
    const [user, setUser] = useState('UserName');

    return (
        <UserContext.Provider value={user}>
            <div>
                <h1>Context Provider</h1>
                <div>
                    <input type="text" onChange={(e) => setUser(e.target.value)} />
                </div>
                <div>
                    <ContextConsumer />
                </div>
            </div>
        </UserContext.Provider>
    );
};

export default ContextProvider;