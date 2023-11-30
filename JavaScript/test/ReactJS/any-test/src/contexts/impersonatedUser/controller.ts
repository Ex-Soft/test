import { useState, useCallback } from "react";
import { ImpersonatedUserContextProps } from "./context";

export const useImpersonatedUserContextController =
  (): ImpersonatedUserContextProps => {
    const [impersonatedUserName, setImpersonatedUserName] = useState<
      string | undefined
    >();

    const setState = useCallback(
      (name?: string) => {
        setImpersonatedUserName(name);
      },
      [setImpersonatedUserName]
    );

    return { name: impersonatedUserName, setState };
  };
