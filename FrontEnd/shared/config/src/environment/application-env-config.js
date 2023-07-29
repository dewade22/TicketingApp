export default class ApplicationEnvConfig {
    constructor() {
        this.isDevelopmentInstance = process.env.IS_DEVELOPMENT_INSTANCE;
    }
}