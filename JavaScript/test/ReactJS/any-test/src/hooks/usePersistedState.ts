import { Dispatch, SetStateAction, useEffect, useState } from "react";

type Response<T> = [T, Dispatch<SetStateAction<T>>];

export function usePersistedState<T>(
  key: string,
  initialState: T
): Response<T> {
  const getLocalStorageValue = (key: string): any => {
    let result = undefined;

    const localStorageValue = localStorage.getItem(key);

    if (!!localStorageValue) {
      try {
        result = JSON.parse(localStorageValue);
      } catch {
        result = localStorageValue;
      }
    }

    return result;
  };

  const [state, setState] = useState<any | null | undefined>(() => {
    console.log("usePersistedState.useState()");

    return getLocalStorageValue(key) || initialState;
  });

  useEffect(() => {
    console.log("usePersistedState.useEffect() [key = %o, state = %o]", key, state);

    state !== undefined && localStorage.setItem(key, JSON.stringify(state));
  }, [key, state]);

  return [state, setState];
}
