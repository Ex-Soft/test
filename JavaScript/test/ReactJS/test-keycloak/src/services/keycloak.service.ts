import axios from 'axios';
import { wrapper } from 'axios-cookiejar-support';
import { CookieJar } from 'tough-cookie';

export class KeyCloakService {
    private keycloakProtocol: string = "http"; //"https";
    private keycloakHost: string = "localhost";
    private keycloakPort: string = "8080"; //"443";
    private keycloakRealm: string = "myrealm";

    private keycloakClientID: string = "react-auth";
    private keycloakClientSecret: string = "keycloakClientSecret";

    public async obtainServiceAccountToken(keycloakRealm?: string) {
        const url = `${this.keycloakProtocol}://${this.keycloakHost}:${this.keycloakPort}/auth/realms/${keycloakRealm || this.keycloakRealm}/protocol/openid-connect/token`;
        
        const data = {
            client_id: this.keycloakClientID,
            client_secret: this.keycloakClientSecret,
            grant_type: "client_credentials"
        };

        const config = {
            headers: {
                "Content-Type": "application/x-www-form-urlencoded"
            }
        };

        let response;

        try {
            response = await axios.post(url, data, config);
            console.log("\"%s\" = %o", this.keycloakClientID, response?.data);
        }
        catch (error) {
            console.log(error);
        }

        return response?.status === 200 && response?.data ? response?.data : undefined;
    }
    
    public async obtainImpersonatorToken(refresh_token?: string) {
        const url = `${this.keycloakProtocol}://${this.keycloakHost}:${this.keycloakPort}/auth/realms/${this.keycloakRealm}/protocol/openid-connect/token`;
        
        const data = {
            client_id: this.keycloakClientID,
            client_secret: this.keycloakClientSecret,
            //grant_type: "client_credentials",
            ...!!refresh_token && { grant_type: "refresh_token", refresh_token: refresh_token },
            ...!refresh_token && { grant_type: "password", username: "anonymous@mailinator.com", password: "password" }
        };

        const config = {
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
                ...!!refresh_token && { Authorization: `Bearer ${refresh_token}`}
            }
        };

        let response;

        try {
            response = await axios.post(url, data, config);
        }
        catch (error) {
            console.log(error);
        }

        return response?.status === 200 && response?.data ? response?.data : undefined;
    }

    public async getUserId(userName: string) {
        if (!userName)
            return undefined;

        const serviceAccountToken = await this.obtainServiceAccountToken();
        if (!serviceAccountToken)
            return undefined;

        const url = `${this.keycloakProtocol}://${this.keycloakHost}:${this.keycloakPort}/auth/admin/realms/${this.keycloakRealm}/users?username=${userName}`;
        
        const config = {
            headers: {
                Authorization: `${serviceAccountToken.token_type} ${serviceAccountToken.access_token}`
            }
        };

        let response;

        try {
            response = await axios.get(url, config);
        }
        catch (error) {
            console.log(error);
        }

        console.log(response?.data?.[0]);

        return response?.status === 200 && Array.isArray(response?.data) && response?.data.length  ? response?.data[0].id : undefined;
    }

    public async impersonateUser(token: any, userId: string) {
        if (!token || !userId)
            return undefined;

        const url = `${this.keycloakProtocol}://${this.keycloakHost}:${this.keycloakPort}/auth/admin/realms/${this.keycloakRealm}/users/${userId}/impersonation`;

        const data = {
            realm: this.keycloakRealm,
            user: userId,
            /*client_id: this.keycloakClientID,
            client_secret: this.keycloakClientSecret,
            grant_type: "password",
            username: "anonymous@mailinator.com",
            password: "password"*/
        };

        const jar = new CookieJar();

        const config = {
            headers: {
                "Content-Type": "application/json;charset=utf-8",
                Authorization: `${token.token_type} ${token.access_token}`
            },
            jar
        };
        
        let response;

        try {
            response = await axios.post(url, data, config);
            console.log(response?.config?.jar?.toJSON());
        }
        catch (error) {
            console.log(error);
        }

        return response?.status === 200 && response?.data ? response?.data : undefined;
    }

    public async impersonateUser2(token: any, userId: string) {
        if (!token || !userId)
            return undefined;

        const url = `${this.keycloakProtocol}://${this.keycloakHost}:${this.keycloakPort}/auth/admin/realms/${this.keycloakRealm}/users/${userId}/impersonation`;
        
        const data = {
            realm: this.keycloakRealm,
            user: userId,
            client_id: this.keycloakClientID,
            client_secret: this.keycloakClientSecret,
            grant_type: "client_credentials",
            /*grant_type: "password",
            username: "anonymous@mailinator.com",
            password: "password"*/
        };

        const config = {
            headers: {
                "Content-Type": "application/json;charset=utf-8",
                Authorization: `${token.token_type} ${token.access_token}`
            }
        };

        let response;

        try {
            response = await axios.post(url, data, config);
        }
        catch (error) {
            console.log(error);
        }

        return response?.status === 200 && response?.data ? response?.data : undefined;
    }

    public async obtainTokenBasedOnIdentity(token: any, userId: string) {
        const url = `${this.keycloakProtocol}://${this.keycloakHost}:${this.keycloakPort}/auth/realms/${this.keycloakRealm}/protocol/openid-connect/auth?response_mode=fragment&response_type=token&client_id=${this.keycloakClientID}&redirect_uri=http%3A%2F%2Flocalhost%3A3000%2Fauth%2Frealms%2Fthe-marketing-zone-dev%2Faccount`;

        const config = {
            headers: {
                "Content-Type": "application/json;charset=utf-8",
                Authorization: `${token.token_type} ${token.access_token}`
            }
        };
        
        let response;

        try {
            response = await axios.get(url, config);
            console.log(response?.data);
        }
        catch (error) {
            console.log(error);
        }

        return response?.status === 200 && response?.data ? response?.data : undefined;
    }

    public async exchangeToken(token: any, userId: string) {
        const url = `${this.keycloakProtocol}://${this.keycloakHost}:${this.keycloakPort}/auth/realms/${this.keycloakRealm}/protocol/openid-connect/token`;
        
        const data = {
            client_id: this.keycloakClientID,
            client_secret: this.keycloakClientSecret,
            grant_type: "urn:ietf:params:oauth:grant-type:token-exchange",
            requested_subject: userId,
            subject_token: token.access_token,
            requested_token_type: "urn:ietf:params:oauth:token-type:access_token",
            audience: "target-client"
        };

        const config = {
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
                Authorization: `${token.token_type} ${token.access_token}`
            }
        };

        let response;

        try {
            response = await axios.post(url, data, config);
        }
        catch (error) {
            console.log(error);
        }

        return response?.status === 200 && response?.data ? response?.data : undefined;
    }
}