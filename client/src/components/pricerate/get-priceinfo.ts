import {autoinject} from 'aurelia-dependency-injection';
import { observable } from "aurelia-framework";
import {EventAggregator} from 'aurelia-event-aggregator';
import {ValidationControllerFactory, ValidationController, ValidationRules } from "aurelia-validation";
import Swal from 'sweetalert2';
import { IconAPI } from '../../api/agent';
import {PriceRateCreated} from '../messages';
import { BootstrapFormRenderer } from '../../helper/bootstrap-form-renderer';


interface PriceDetails {
  dimensionValue: number;
  deight: number;
  price: number;
}

interface PriceDetailsDto {
  width: number;
  height: number;
  depth: number;
  weight: number;
}

@autoinject
export class PriceDetailClass {
  routeConfig;
  pricedetails: PriceDetails;
  originalPriceDetails: PriceDetails;
  controller: ValidationController;
  public locales: { key: string; label: string }[];
  @observable
  public currentLocale: string;

  constructor(private api: IconAPI, private ea: EventAggregator, private controllerFactory: ValidationControllerFactory) { 
    this.controller = this.controllerFactory.createForCurrentScope();
    
    this.controller.addRenderer(new BootstrapFormRenderer());
    this.controller.addObject(this);
    this.controller.reset({ object: this.pricedetails, propertyName: 'pricebooked' });
  

  }

  public bind() {
    this.controller.validate();
  }

  create(p1,p2,p3,p4) {
    var newPriceDetails: PriceDetailsDto = {
      weight:p1,
      width: p2,
      height:p3,
      depth:p4,
    }
    this.controller.validate()
    .then((validate) => {
      if(validate.valid) {
        return this.api.getPriceRates(newPriceDetails).then(pricedetails => {
          this.pricedetails = <PriceDetails>pricedetails;
          this.originalPriceDetails = JSON.parse(JSON.stringify(this.pricedetails));
          this.ea.publish(new PriceRateCreated(this.pricedetails));
        });
      } else {
        console.log('E no enter');
      }
    });
      
    
  }

  reset(){
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, reset it!'
    }).then((result) => {
      if (result.isConfirmed) {
        window.location.reload();
      }
    })
  }

  
  canSave() {
    this.controller.validate()
    .then((validate) => {
      if(validate.valid) {
        console.log(validate.valid)
        return true;
      } else {
        console.log(validate.valid)
        return false;
      }
    });
  }

  canReset(params) {
    if (params === undefined) {
      return !this.api.isRequesting;
    }
  }


}

ValidationRules
  .ensure('weight').required()
  .withMessage('Weight must be provided.')
  .ensure('width').required()
  .withMessage('Width must be provided.')
  .ensure('height').required()
  .withMessage('Height must be provided.')
  .ensure('depth').required()
  .withMessage('Depth must be provided.')
  .on(PriceDetailClass);
  
  

  