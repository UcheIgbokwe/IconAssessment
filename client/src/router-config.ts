import {AuthorizeStep} from 'aurelia-auth';
import {autoinject, PLATFORM} from 'aurelia-framework';
import {Router, RouterConfiguration} from 'aurelia-router';

@autoinject()
export default class {
  router: Router;

	constructor(router: Router) {
		this.router = router;
	}

  configure() {
	  let appRouterConfig: any = function(config: RouterConfiguration): void {
	    config.title = 'Icon Portal';
			config.addPipelineStep('authorize', AuthorizeStep); // Add a route filter to the authorize extensibility point.
      config.options.pushState = true;
      config.options.root = '/';
	    config.map([
        { route: ['', 'login'], name: 'login',   moduleId: PLATFORM.moduleName('./components/login/welcome'),  title: 'Login' },
        { route: ['welcome'],   name: 'priceinfo',  moduleId: PLATFORM.moduleName('./components/pricerate/get-priceinfo'), title:'Price Rates' }, 
      ]);
	  };

    this.router.configure(appRouterConfig);
	}
}
