import BaseService from "./base-service";

export default class AuthenticationService extends BaseService {
    constructor() {
        super("user-account");
        this.options = {
            headers: {
                "Content-Type": "application/json"
            },
        };

        this.accessToken = "_app_accessToken";
        this.baseApiUrl = "http://localhost:5272";
    }

    SignIn(model, version) {
        let options = { headers: {contentType: "application/json" } };

        return this._Post(
            `${this.baseApiUrl}/${version ?? this.defaultVersion}/${this.baseController}/signin`,
            model,
            options
        );
    }
}