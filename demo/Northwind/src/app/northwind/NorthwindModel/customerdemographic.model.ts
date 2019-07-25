import { Customer } from './customer.model';
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class CustomerDemographic extends ODataModel {
  static type = 'NorthwindModel.CustomerDemographic';
  static schema = Schema.create({
    keys: [
        'CustomerTypeID'
    ],
    fields: [
      {name: 'CustomerTypeID', required: true, type: 'String', length: 10},
      {name: 'CustomerDesc', required: true, type: 'String'},
      {name: 'Customers', required: false, type: 'NorthwindModel.CustomerCollection'}
    ],
    defaults: {}
  });
  CustomerTypeID: string;
  CustomerDesc: string;

  public getCustomers(): ODataCollection<Customer> {
    return this.relatedODataCollection('Customers') as ODataCollection<Customer>;
  }
  public addCustomerToCustomers(target: ODataQueryBase, options?) {
    return this.createODataCollectionRef('Customers', target, options);
  }
  public removeCustomerFromCustomers(target: ODataQueryBase, options?) {
    return this.deleteODataCollectionRef('Customers', target, options);
  }
}