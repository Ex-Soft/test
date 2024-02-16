import { useState, useEffect } from "react";

export const useTestState = (
  initialData?: any
): { data: any; setData: Function } => {
  const [data, _setData] = useState(initialData);

  useEffect(() => {
    const timeout = setTimeout(() => {
      _setData({
        p1: "p1 Initial value by setTimeout",
        p2: "p2 Initial value by setTimeout",
        p3: "p3 Initial value by setTimeout",
      });
    }, 2000);

    return () => clearTimeout(timeout);
  }, []);

  return { data, setData: _setData };
};
