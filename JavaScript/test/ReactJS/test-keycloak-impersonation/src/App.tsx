import { useState } from "react";
import Keycloak from "keycloak-js";
import { AuthClientInitOptions } from "@react-keycloak/core";
import { ReactKeycloakProvider } from "@react-keycloak/web";
import axios from 'axios';

/*const config = {
  "realm": "myrealm",
  "auth-server-url": "http://localhost:8080/auth/",
  "ssl-required": "external",
  "resource": "react-auth",
  "public-client": true,
  "confidential-port": 0
};*/

const config = "./keycloak.json";

const keycloak = new (Keycloak as any)(config);

function handleKeycloakOnEvent(eventType: any, error: any) {
  console.log("eventType = \"%s\" error = %o", eventType, error);
}

function handleKeycloakOnTokens(tokens: any) {
  console.log("tokens = %o", tokens);
}

function App() {
  const [initOptions, setInitOptions] = useState<AuthClientInitOptions | undefined>();

  async function impersonate() {
    const impersonatorTokens = await getImpersonatorTokens();
    const impersonatedTokens = await getImpersonatedTokens(impersonatorTokens?.access_token);

    setInitOptions(!!impersonatedTokens?.access_token && !!impersonatedTokens?.refresh_token ? {token: impersonatedTokens?.access_token, refreshToken: impersonatedTokens?.refresh_token, /* onLoad: "login-required"*/} : undefined);
  }
  
  function getImpersonatorTokens() {
    return token({
      client_id: "react-auth",
      grant_type: "password",
      username: "myuser",
      password: "myuser"
    });
  }
  
  function getImpersonatedTokens(accessToken?: string) {
    return token({
      client_id: "react-auth",
      grant_type: "urn:ietf:params:oauth:grant-type:token-exchange",
      requested_subject: "testuser",
      subject_token: accessToken,
      requested_token_type: "urn:ietf:params:oauth:token-type:refresh_token",
      audience: "react-auth"
    }, `Bearer ${accessToken}`);
  }

  async function token(data?: any, authorization?: string) {
    const url = "http://localhost:8080/auth/realms/myrealm/protocol/openid-connect/token";
  
    const config = {
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
        ...!!authorization && { Authorization: authorization }
      }
    };
  
    let response;
  
    try {
      response = await axios.post(url, data, config);
    }
    catch (error) {
      console.log(error);
    }
  
    return response?.data;
  }

  return (
    <div>
      <ReactKeycloakProvider
        initOptions={initOptions}
        authClient={keycloak}
        onEvent={handleKeycloakOnEvent}
        onTokens={handleKeycloakOnTokens}
      >
        <input type="button" value="Impersonate" onClick={impersonate} />
        <input type="button" value="keycloak" onClick={() => console.log(keycloak)} />
        <input type="button" value="login" onClick={() => keycloak.login()} />
        <input type="button" value="logout" onClick={() => keycloak.logout()} />
      </ReactKeycloakProvider>
    </div>
  );
}

export default App;

// yarn create react-app test-keycloak-impersonation --template typescript
// yarn add keycloak-js@16.1.1 @react-keycloak/web@3.4.0 react-router-dom
// yarn add axios