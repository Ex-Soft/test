import { useContext, useEffect, useState } from "react";
import "./index.css";

import { UserContext } from "../ContextProvider";
import { useImpersonatedUser } from "../../../contexts";

const ContextConsumer: React.FC = () => {
  const { name: impersonatedUserName } = useImpersonatedUser();
  const [impersonatedUser, setImpersonatedUser] = useState<
    string | undefined
  >();

  console.log("impersonatedUserName: %o", impersonatedUserName);

  const user = useContext(UserContext);

  useEffect(() => {
    console.log("useEffect() impersonatedUserName: %o", impersonatedUserName);
    setImpersonatedUser(impersonatedUserName);
  }, [impersonatedUserName]);

  return (
    <div>
      <div>
        <p>useImpersonatedUser() {impersonatedUser}</p>
      </div>
      <h1>Context Consumer</h1>
      <p>Context Consumer: {user}</p>
    </div>
  );
};

export default ContextConsumer;
