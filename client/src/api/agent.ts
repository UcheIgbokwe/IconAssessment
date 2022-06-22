import {HttpClient, json} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';
import * as toastr from 'toastr';

@inject(HttpClient)
export class IconAPI{
  isRequesting = false;

  constructor(private http: HttpClient) {
    const baseUrl = 'http://localhost:8000/api/';

    http.configure(config => {
      config.withBaseUrl(baseUrl);
    })
  }

  //Get price rate
  getPriceRates(getPriceCommand){
    this.isRequesting = true;
    return this.http.fetch(`Price/GetBestRate`, {
      method: 'post',
      body: json(getPriceCommand)
    })
    .then(response => response.json())
    .then(result => {
      this.isRequesting = false;
      return result;
    })
    .catch(errorLog => {
      if(!this.IsJson(errorLog))
      {
        this.isRequesting = false
        toastr.error("Please try again", 'Error!')
        return [];
      }
      this.isRequesting = false
      toastr.error(errorLog, 'Error!')
      return [];
    }); 
  }

  IsJson(str) {
    try {
        JSON.parse(str);
    } catch (e) {
        return false;
    }
    return true;
  }

}
