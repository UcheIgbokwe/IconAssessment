import {Router, RouterConfiguration} from 'aurelia-router';
import { PLATFORM, autoinject } from 'aurelia-framework';
import { FetchConfig} from 'aurelia-auth';
import AppRouterConfig from './router-config';


@autoinject()
export class App {
  fetchConfig: FetchConfig;
  router: Router;
  appRouterConfig: AppRouterConfig;

  constructor(appRouterConfig: AppRouterConfig, router: Router, fetchConfig: FetchConfig) {
    this.appRouterConfig = appRouterConfig;
    this.router = router;
    this.fetchConfig = fetchConfig;
  }

  activate() {
    this.appRouterConfig.configure();
    this.fetchConfig.configure();
  }
}
