import { registerApplication, start } from "single-spa";
import { BehaviorSubject } from "rxjs";
import {
  constructApplications,
  constructRoutes,
  constructLayoutEngine,
} from "single-spa-layout";
import microfrontendLayout from "./microfrontend-layout.html";

const pubSubEngine = new BehaviorSubject("");
const data = {
  props: {
    emitMulticastMessage: (message) => pubSubEngine.next(message),
    subscribeMulticastMessage: (callback) =>pubSubEngine.subscribe(callback)
  }
}
const routes = constructRoutes(microfrontendLayout, data);
const applications = constructApplications({
  routes,
  loadApp({ name }) {
    return System.import(name);
  },
});
const layoutEngine = constructLayoutEngine({ routes, applications });

applications.forEach(registerApplication);
layoutEngine.activate();
start();
