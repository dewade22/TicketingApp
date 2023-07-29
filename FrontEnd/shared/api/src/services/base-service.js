import axios from "axios";
import Cookies from "js-cookie";
import { ApiEnvConfig } from "@tapp/shared-config";

const config = new ApiEnvConfig();
export default class BaseService{
    constructor(baseController, defaultVersion){
        this.baseApiUrl = config.baseApiUrl;
        this.baseController = baseController;
        this.defaultVersion = defaultVersion ?? "v1";
        this.accessToken = "_app_accessToken";
    }

    _Get(url, options) {
        return axios.get(url, options);
    }

    _Post(url, data, config) {
        return axios.post(url, data, config);
    }

    _Put(url, data, config) {
        return axios.put(url, data, config);
    }

    _Patch(url, data, config) {
        return axios.patch(url, data, config);
    }

    _Delete(url, config) {
        return axios.delete(url, config);
    }

    _GetCancelToken() {
        return axios.CancelToken.source();
    }

    Create(model, version) {
        let options = { headers: {contentType: "application/json" } };
        let accessToken = Cookies.get(this.accessToken);

        if (accessToken && accessToken !== "") {
            Object.assign(options.headers, {
                authorization: `bearer ${accessToken}`,
            });
        }

        return this._Post(
            `${this.baseApiUrl}/${version ?? this.defaultVersion}/${
                this.baseController
            }`,
            model,
            options
        );
    }

    Read(id, version) {
        let options = { headers: {contentType: "application/json" } };
        let accessToken = Cookies.get(this.accessToken);

        if (accessToken && accessToken !== "") {
            Object.assign(options.headers, {
                authorization: `bearer ${accessToken}`,
            });
        }

        return this._Get(
            `${this.baseApiUrl}/${version ?? this.defaultVersion}/${
                this.baseController
            }/${id}`,
            options
        );
    }

    Update(id, model, version) {
        let options = { headers: {contentType: "application/json" } };
        let accessToken = Cookies.get(this.accessToken);

        if (accessToken && accessToken !== "") {
            Object.assign(options.headers, {
                authorization: `bearer ${accessToken}`,
            });
        }

        return this._Put(
            `${this.baseApiUrl}/${version ?? this.defaultVersion}/${
                this.baseController
            }/${id}`,
            model,
            options
        )
    }

    Delete(id, version) {
        let options = { headers: {contentType: "application/json" } };
        let accessToken = Cookies.get(this.accessToken);

        if (accessToken && accessToken !== "") {
            Object.assign(options.headers, {
                authorization: `bearer ${accessToken}`,
            });
        }

        return this._Delete(
            `${this.baseApiUrl}/${version ?? this.defaultVersion}/${
                this.baseController
            }/${id}`,
            options
        );
    }
}