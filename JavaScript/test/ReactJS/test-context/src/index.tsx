import React, { createContext, useState, useEffect, useContext } from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { CartContextProvider } from "./contexts/cart";

export interface Settings {
  p1?: string;
  p2?: string;
  p3?: string;
}

interface SettingsContextProps {
  settings?: Settings;
}

const SettingsContext = createContext<SettingsContextProps>({
  settings: undefined,
});

const useSettingsContextController = (): SettingsContextProps => {
  console.log("useSettingsContextController()");
  const [settings, setSettings] = useState<Settings | undefined>(undefined);

  useEffect(() => {
    const timeout = setTimeout(() => {
      console.log("useSettingsContextController() -> setSettings()");
      setSettings({ p1: "p1 value", p2: "p2 value", p3: "p3 value" });
    }, 5000);

    return () => clearTimeout(timeout);
  }, []);

  return { settings };
};

const SettingsContextProvider: React.FC<{ children: any }> = ({ children }) => {
  return (
    <SettingsContext.Provider value={{ ...useSettingsContextController() }}>
      {children}
    </SettingsContext.Provider>
  );
};

export function useSettings(): SettingsContextProps {
  const context = useContext(SettingsContext);

  if (!context) {
    throw new Error(
      "useSettings must be used within a SettingsContextProvider."
    );
  }

  return context;
}

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);
root.render(
  <React.StrictMode>
    <SettingsContextProvider>
      <CartContextProvider>
        <App />
      </CartContextProvider>
    </SettingsContextProvider>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
