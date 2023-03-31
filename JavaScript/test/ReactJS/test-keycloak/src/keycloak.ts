import Keycloak from "keycloak-js";

/*const config = {
  url: "http://localhost:8080/",
  realm: "myrealm",
  clientId: "React-auth",
};*/

const config = "./keycloak.json";

export const keycloak = new Keycloak(config);
