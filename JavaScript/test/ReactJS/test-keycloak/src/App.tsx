import { ReactKeycloakProvider } from "@react-keycloak/web";
import { keycloak } from "./keycloak";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Nav } from "./components";
import { WelcomePage, SecuredPage } from "./pages";
import { PrivateRoute } from "./helpers/PrivateRoute";

function App() {
  return (
    <div>
      <ReactKeycloakProvider authClient={keycloak}>
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

// yarn create react-app test-keycloak --template typescript
// yarn add keycloak-js @react-keycloak/web react-router-dom
