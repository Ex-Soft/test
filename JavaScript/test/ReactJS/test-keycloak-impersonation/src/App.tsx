// https://blog.softwaremill.com/who-am-i-keycloak-impersonation-api-bfe7acaf051a
// https://keycloak.discourse.group/t/impersonate-user-via-keycloak-api/6748/3
// https://okraskat.github.io/impersonation-in-keycloak/
// https://stackoverflow.com/questions/57496638/keycloak-impersonation-api-not-implemented
// https://stackoverflow.com/questions/76737735/keycloak-impersonation-in-react
// https://github.com/keycloak/keycloak/discussions/21881


import { useState } from "react";
import Keycloak from "keycloak-js";
import { AuthClientInitOptions } from "@react-keycloak/core";
import { ReactKeycloakProvider } from "@react-keycloak/web";
import axios from 'axios';

// const config = {
//   realm: "myrealm",
//   url: "http://localhost:8080/auth/",
//   clientId: "react-auth" // "admin-dev"
// };
// const impersonatorUserName = "myuser";
// const impersonatorPassword = "myuser";
// const testUserId = "09af0adc-bc5f-4b1e-9cf7-1d8e9b976217";
// const requestedSubject = "testuser";

// const config = {
//   realm: "the-marketing-zone-dev",
//   url: "https://auth-dev.thedirectvmarketingzone.com/auth/",
//   clientId: "admin-dev"
// };
// const impersonatorUserName = "myuser@mailinator.com";
// const impersonatorPassword = "myuser";
// const testUserId = "c97fb064-b0e7-4913-9889-88df6304bdec";
// const requestedSubject = "testuser@mailinator.com";

const config = {
  realm: "the-marketing-zone-stg",
  url: "https://auth-staging.thedirectvmarketingzone.com/auth/",
  clientId: "admin-stg"
};
const impersonatorUserName = "myuser@mailinator.com";
const impersonatorPassword = "myuser";
const testUserId = "92e9bb3e-a613-4984-a367-15843d1c32b8";
const requestedSubject = "testuser@mailinator.com";

const keycloak = new (Keycloak as any)(config);

function handleKeycloakOnEvent(eventType: any, error: any) {
  console.log("eventType = \"%s\" error = %o", eventType, error);
}

function handleKeycloakOnTokens(tokens: any) {
  console.log("tokens = %o", tokens);
}

function App() {
  const [initOptions, setInitOptions] = useState<AuthClientInitOptions | undefined>();

  async function impersonateByTokenExchange() {
    let impersonatorAccessToken = keycloak?.token;

    if (!impersonatorAccessToken) {
      const impersonatorTokens = await getImpersonatorTokens();
      impersonatorAccessToken = impersonatorTokens?.access_token;
    }

    const impersonatedTokens = await getImpersonatedTokens(impersonatorAccessToken);

    setInitOptions(!!impersonatedTokens?.access_token && !!impersonatedTokens?.refresh_token ? {token: impersonatedTokens?.access_token, refreshToken: impersonatedTokens?.refresh_token, /* onLoad: "login-required"*/} : undefined);
  }
  
  function getImpersonatorTokens() {
    return token({
      client_id: config.clientId,
      grant_type: "password",
      username: impersonatorUserName,
      password: impersonatorPassword
    });
  }
  
  function getImpersonatedTokens(accessToken?: string) {
    return token({
      client_id: config.clientId,
      grant_type: "urn:ietf:params:oauth:grant-type:token-exchange",
      requested_subject: requestedSubject,
      subject_token: accessToken,
      requested_token_type: "urn:ietf:params:oauth:token-type:refresh_token",
      audience: config.clientId
    }, `Bearer ${accessToken}`);
  }

  async function token(data?: any, authorization?: string) {
    const url = `${config.url}realms/${config.realm}/protocol/openid-connect/token`;
  
    const axiosRequestConfig = {
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
        ...!!authorization && { Authorization: authorization }
      }
    };
  
    let response;
  
    try {
      response = await axios.post(url, data, axiosRequestConfig);
    }
    catch (error) {
      console.log(error);
    }
  
    return response?.data;
  }

  async function impersonateByImpersonationFE() {
    const impersonatorTokens = await getImpersonatorTokens();
    const impersonateData = await impersonate({
      realm: config.realm,
      user: testUserId
    }, `Bearer ${impersonatorTokens.access_token}`);
  }

  async function impersonate(data?: any, authorization?: string) {
    const url = `${config.url}admin/realms/${config.realm}/users/${data?.user}/impersonation`;
  
    const axiosRequestConfig = {
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
        ...!!authorization && { Authorization: authorization }
      }
    };
  
    let response;
  
    try {
      response = await axios.post(url, data, axiosRequestConfig);
      console.log(response?.headers["set-cookie"]);
    }
    catch (error) {
      console.log(error);
    }
  
    return response?.data;
  }

  async function impersonateByImpersonationBE() {
    try {
      const response = await axios.get("http://localhost:5014/impersonateByImpersonation");
      if (!!response?.data?.redirectUriCode) {
        const callbackState = {
          state: response?.data?.sessionState,
          redirectUri: encodeURIComponent('http://localhost:3000/'),
          prompt: 'none',
          expires: new Date().getTime() + (60 * 60 * 1000)
        };
        const key = 'kc-callback-' + callbackState.state;
        localStorage.setItem(key, JSON.stringify(callbackState));
        window.location.href = response?.data?.redirectUriCode + `&state=${response?.data?.sessionState}`;
        window.location.reload();
      }
    }
    catch (error) {
      console.log(error);
    }
  }

  return (
    <div>
      <ReactKeycloakProvider
        initOptions={initOptions}
        authClient={keycloak}
        onEvent={handleKeycloakOnEvent}
        onTokens={handleKeycloakOnTokens}
      >
        <input type="button" value="Impersonate (token-exchange)" onClick={impersonateByTokenExchange} />
        <input type="button" value="Impersonate (impersonation) (FE)" onClick={impersonateByImpersonationFE} />
        <input type="button" value="Impersonate (impersonation) (BE)" onClick={impersonateByImpersonationBE} />
        <input type="button" value="keycloak" onClick={() => console.log(keycloak)} />
        <input type="button" value="login" onClick={() => keycloak.login()} />
        <input type="button" value="logout" onClick={() => keycloak.logout()} />
      </ReactKeycloakProvider>
    </div>
  );
}

export default App;

// yarn create react-app test-keycloak-impersonation --template typescript
// yarn add keycloak-js@16.1.1 @react-keycloak/web@3.4.0 react-router-dom axios
// yarn upgrade

// docker run -it --rm --name keycloak -v /d/temp:/mnt -p 8080:8080 -e KEYCLOAK_USER=admin -e KEYCLOAK_PASSWORD=admin -e JAVA_OPTS_APPEND="-Dkeycloak.profile=preview -Dkeycloak.profile.feature.token_exchange=enabled" -e DEBUG=true quay.io/keycloak/keycloak:15.1.0
// docker run -it --rm --name keycloak -v /d/temp:/mnt -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:22.0.3 start-dev --features="preview"

// myrealm

// Client
// react-auth
// Access Type: public
// Implicit Flow Enabled: ON
// Valid Redirect URIs: * | http://localhost:3000/*
// Web Origins: * | http://localhost:3000
// Permissions -> Permissions Enabled: ON
// Permissions -> token-exchange -> create client policy (react-auth-token-exchange)

// Users
// myuser
// testuser
// Permissions -> Permissions Enabled: ON
// Permissions -> impersonate -> create client policy (react-auth-impersonate)