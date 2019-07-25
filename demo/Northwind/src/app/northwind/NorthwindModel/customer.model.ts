import { CustomerDemographic } from './customerdemographic.model';
import { Order } from './order.model';
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Customer extends ODataModel {
  static type = 'NorthwindModel.Customer';
  static schema = Schema.create({
    keys: [
        'CustomerID'
    ],
    fields: [
      {name: 'CustomerID', required: true, type: 'String', length: 5},
      {name: 'CompanyName', required: true, type: 'String', length: 40},
      {name: 'ContactName', required: true, type: 'String', length: 30},
      {name: 'ContactTitle', required: true, type: 'String', length: 30},
      {name: 'Address', required: true, type: 'String', length: 60},
      {name: 'City', required: true, type: 'String', length: 15},
      {name: 'Region', required: true, type: 'String', length: 15},
      {name: 'PostalCode', required: true, type: 'String', length: 10},
      {name: 'Country', required: true, type: 'String', length: 15},
      {name: 'Phone', required: true, type: 'String', length: 24},
      {name: 'Fax', required: true, type: 'String', length: 24},
      {name: 'Orders', required: false, type: 'NorthwindModel.OrderCollection'},
      {name: 'CustomerDemographics', required: false, type: 'NorthwindModel.CustomerDemographicCollection'}
    ],
    defaults: {}
  });
  CustomerID: string;
  CompanyName: string;
  ContactName: string;
  ContactTitle: string;
  Address: string;
  City: string;
  Region: string;
  PostalCode: string;
  Country: string;
  Phone: string;
  Fax: string;

  public getOrders(): ODataCollection<Order> {
    return this.relatedODataCollection('Orders') as ODataCollection<Order>;
  }
  public addOrderToOrders(target: ODataQueryBase, options?) {
    return this.createODataCollectionRef('Orders', target, options);
  }
  public removeOrderFromOrders(target: ODataQueryBase, options?) {
    return this.deleteODataCollectionRef('Orders', target, options);
  }
  public getCustomerDemographics(): ODataCollection<CustomerDemographic> {
    return this.relatedODataCollection('CustomerDemographics') as ODataCollection<CustomerDemographic>;
  }
  public addCustomerDemographicToCustomerDemographics(target: ODataQueryBase, options?) {
    return this.createODataCollectionRef('CustomerDemographics', target, options);
  }
  public removeCustomerDemographicFromCustomerDemographics(target: ODataQueryBase, options?) {
    return this.deleteODataCollectionRef('CustomerDemographics', target, options);
  }
}