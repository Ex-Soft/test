import { Dispatch, SetStateAction, useEffect, useState } from "react";
import { isObject } from "../utils";

type Response<T> = [T, Dispatch<SetStateAction<T>>];

export function usePersistedSubState<T>(
  key: string,
  subKey: string,
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
    console.log("usePersistedSubState.useState()");
    let result = getLocalStorageValue(key);
    return isObject(result)
      ? !!subKey
        ? (result as { [key: string]: any })[subKey]
        : initialState
      : result || initialState;
  });

  useEffect(() => {
    console.log("usePersistedSubState.useEffect() [key = %o, subKey = %o, state = %o]", key, subKey, state);

    if (state === undefined || !subKey) return;

    let localStorageValue = getLocalStorageValue(key);

    if (localStorageValue === undefined)
      localStorageValue = { [subKey]: state };
    else if (isObject(localStorageValue))
      (localStorageValue as { [key: string]: any })[subKey] = state;
    else localStorageValue = { [subKey]: state };

    localStorage.setItem(key, JSON.stringify(localStorageValue));
  }, [key, subKey, state]);

  return [state, setState];
}
