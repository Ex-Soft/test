import { useContext } from "react";
import {
  ImpersonatedUserContext,
  ImpersonatedUserContextProps,
} from "./context";
import { useImpersonatedUserContextController } from "./controller";

const ImpersonatedUserContextProvider: React.FC<{ children: any }> = ({ children }) => {
  return (
    <ImpersonatedUserContext.Provider
      value={{ ...useImpersonatedUserContextController() }}
    >
      {children}
    </ImpersonatedUserContext.Provider>
  );
};

function useImpersonatedUser(): ImpersonatedUserContextProps {
  const context = useContext(ImpersonatedUserContext);

  if (!context) {
    throw new Error(
      "useImpersonatedUser must be used within a ImpersonatedUserContextProvider."
    );
  }

  return context;
}

export { ImpersonatedUserContextProvider, useImpersonatedUser };
