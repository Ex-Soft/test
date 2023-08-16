import { useKeycloak } from "@react-keycloak/web";
import { KeyCloakService } from "../services/keycloak.service";

const Home: React.FC = () => {
  const { keycloak } = useKeycloak();

  const obtainServiceAccountToken = async () => {
    const keycloakService = new KeyCloakService();
    const token = await keycloakService.obtainServiceAccountToken();
    console.log(token);
  };

  const obtainImpersonatorToken = async () => {
    const keycloakService = new KeyCloakService();
    const token = await keycloakService.obtainImpersonatorToken();
    console.log(token);
  };
  
  const getUserId = async () => {
    const keycloakService = new KeyCloakService();
    const id = await keycloakService.getUserId("anonymous@mailinator.com");
    console.log(id);
  };

  const impersonateUser = async () => {
    const keycloakService = new KeyCloakService();
    let token = await keycloakService.obtainImpersonatorToken();
    token = await keycloakService.obtainImpersonatorToken(token.refresh_token);
    const id = await keycloakService.getUserId("anonymous@mailinator.com");
    const result = await keycloakService.impersonateUser(token, id);
    console.log(result);
  };
  
  const impersonateUser2 = async () => {
    const keycloakService = new KeyCloakService();
    const token = await keycloakService.obtainServiceAccountToken();
    const result = await keycloakService.impersonateUser2(token, "guid");
    console.log(result);
  };

  const obtainTokenBasedOnIdentity = async () => {
    const keycloakService = new KeyCloakService();
    let token = await keycloakService.obtainImpersonatorToken();
    token = await keycloakService.obtainImpersonatorToken(token.refresh_token);
    const id = await keycloakService.getUserId("anonymous@mailinator.com");
    const result = await keycloakService.obtainTokenBasedOnIdentity(token, id);
    console.log(result);
  };

  const exchangeToken = async () => {
    const keycloakService = new KeyCloakService();
    const token = await keycloakService.obtainImpersonatorToken();
    const id = await keycloakService.getUserId("anonymous@mailinator.com");
    const result = await keycloakService.exchangeToken(token, id);
    console.log(result);
  };

  console.log("HomePage");

  return (
    <div>
      <h1 className="text-green-800 text-4xl">Welcome to the Homepage</h1>
      <hr/>
      <input type="button" value="obtainServiceAccountToken()" onClick={obtainServiceAccountToken} />
      <input type="button" value="obtainImpersonatorToken()" onClick={obtainImpersonatorToken} />
      <input type="button" value="getUserId()" onClick={getUserId} />
      <input type="button" value="impersonateUser()" onClick={impersonateUser} />
      <input type="button" value="impersonateUser2()" onClick={impersonateUser2} />
      <input type="button" value="obtainTokenBasedOnIdentity()" onClick={obtainTokenBasedOnIdentity} />
      <input type="button" value="exchangeToken()" onClick={exchangeToken} />
    </div>
  );
};

export default Home;
