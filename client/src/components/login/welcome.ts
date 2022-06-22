import { json } from 'aurelia-fetch-client';
import {autoinject} from 'aurelia-framework';
import {AuthService} from 'aurelia-auth';
import * as toastr from 'toastr';

@autoinject()
export class Welcome {
  message: string = 'Click button to login';
  firstName: string = 'John';
  lastName: string = 'Doe';

  constructor(private auth: AuthService) {
  }

  submit(): any {
    var model = { email: this.firstName, password: this.lastName }
    
    return this.auth.login(model)
      .then(response => {
      }).catch(err => {
        console.log(`Error : ${err}`);
        toastr.error("Please try again", 'Error!')
      });
	};
  
}

export class UpperValueConverter {
  toView(value: string): string {
    return value && value.toUpperCase();
  }
}
