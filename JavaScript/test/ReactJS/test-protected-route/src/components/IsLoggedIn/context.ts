import { createContext } from "react";

export interface IsLoggedInContextProps {
  isLoggedIn: boolean;
  setIsLoggedIn: (isLoggedIn: boolean) => void;
}

export const IsLoggedInContext = createContext<IsLoggedInContextProps>({
  isLoggedIn: false,
  setIsLoggedIn: () => undefined,
});
