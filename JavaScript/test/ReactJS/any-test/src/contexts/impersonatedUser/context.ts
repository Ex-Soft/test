import { createContext } from "react";

export interface ImpersonatedUserContextProps {
  name?: string;
  setState: (name?: string) => void;
}

export const ImpersonatedUserContext =
  createContext<ImpersonatedUserContextProps>({
    name: undefined,
    setState: () => undefined,
  });
