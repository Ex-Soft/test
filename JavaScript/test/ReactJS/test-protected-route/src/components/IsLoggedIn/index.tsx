import { useContext } from "react";
import { IsLoggedInContext, IsLoggedInContextProps } from "./context";
import { useIsLoggedInContextController } from "./controller";

const IsLoggedInContextProvider: React.FC<{ children: any }> = ({
  children,
}) => {
  return (
    <IsLoggedInContext.Provider value={{ ...useIsLoggedInContextController() }}>
      {children}
    </IsLoggedInContext.Provider>
  );
};

function useIsLoggedIn(): IsLoggedInContextProps {
  const context = useContext(IsLoggedInContext);

  if (!context) {
    throw new Error(
      "useIsLoggedIn must be used within a IsLoggedInContextProvider."
    );
  }

  return context;
}

export { IsLoggedInContextProvider, useIsLoggedIn };
