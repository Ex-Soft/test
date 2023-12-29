import { useState, useCallback } from "react";
import { IsLoggedInContextProps } from "./context";

export const useIsLoggedInContextController = (): IsLoggedInContextProps => {
  const [isLoggedInValue, setIsLoggedInValue] = useState<boolean>(false);

  console.log("useIsLoggedInContextController(%o)", isLoggedInValue);

  const setIsLoggedIn = useCallback(
    (isLoggedIn: boolean) => {
      console.log("setIsLoggedIn(%o)", isLoggedIn);
      setIsLoggedInValue(isLoggedIn);
    },
    [setIsLoggedInValue]
  );

  return { isLoggedIn: isLoggedInValue, setIsLoggedIn };
};
