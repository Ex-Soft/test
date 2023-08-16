import { ReactKeycloakProvider } from "@react-keycloak/web";
import { keycloak } from "./keycloak";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Nav } from "./components";
import { WelcomePage, SecuredPage } from "./pages";
import { PrivateRoute } from "./helpers/PrivateRoute";

function handleKeycloakOnEvent(eventType: any, error: any) {
  console.log("eventType = \"%s\" error = %o", eventType, error);
}

function handleKeycloakOnTokens(tokens: any) {
  console.log("tokens = %o", tokens);
}

function App() {
  return (
    <div>
      <ReactKeycloakProvider
        authClient={keycloak}
        onEvent={handleKeycloakOnEvent}
        onTokens={handleKeycloakOnTokens}
      >
        <Nav />
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<WelcomePage />} />
            <Route
              path="/secured"
              element={
                <PrivateRoute>
                  <SecuredPage />
                </PrivateRoute>
              }
            />
          </Routes>
        </BrowserRouter>
      </ReactKeycloakProvider>
    </div>
  );
}

export default App;

// https://blog.logrocket.com/implement-keycloak-authentication-react/
// yarn create react-app test-keycloak --template typescript
// yarn add keycloak-js @react-keycloak/web react-router-dom
// yarn add axios
// yarn add tough-cookie @types/tough-cookie axios-cookiejar-support
// yarn install --check-files
// yarn upgrade
// yarm start
