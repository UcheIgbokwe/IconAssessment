import {Aurelia} from 'aurelia-framework';
import * as environment from '../config/environment.json';
import {PLATFORM} from 'aurelia-pal';
import 'bootstrap/dist/css/bootstrap.css';
import 'font-awesome/css/font-awesome.css';
import config from './config';

export function configure(aurelia: Aurelia): void {

  aurelia.use
    .standardConfiguration()
    .feature(PLATFORM.moduleName('resources/index'))
    .plugin(PLATFORM.moduleName('aurelia-validation'))
    .plugin(PLATFORM.moduleName('au-table'));

    aurelia.use.plugin(PLATFORM.moduleName('aurelia-auth/auth-filter'));  
    aurelia.use.plugin(PLATFORM.moduleName('aurelia-auth'), baseConfig => {
      baseConfig.configure(config);
    });
  aurelia.use.developmentLogging(environment.debug ? 'debug' : 'warn');


  aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
}
