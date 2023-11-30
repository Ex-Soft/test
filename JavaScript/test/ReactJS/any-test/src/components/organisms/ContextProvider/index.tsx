import { useState, createContext } from "react";
import "./index.css";
import ContextConsumer from "../ContextConsumer";
import { useImpersonatedUser } from "../../../contexts";

export const UserContext = createContext("Unknown");

const ContextProvider: React.FC = () => {
  const [user, setUser] = useState("UserName");
  const { setState: setImpersonatedUserName } = useImpersonatedUser();

  return (
    <UserContext.Provider value={user}>
      <div>
        <div>
          <input
            type="text"
            onChange={(e) => setImpersonatedUserName(e.target.value)}
          />
        </div>
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
