import { useKeycloak } from "@react-keycloak/web";

export const PrivateRoute = ({ children }: { children: any }) => {
  const { keycloak } = useKeycloak();

  const isLoggedIn = keycloak.authenticated;

  return isLoggedIn ? children : null;
};
