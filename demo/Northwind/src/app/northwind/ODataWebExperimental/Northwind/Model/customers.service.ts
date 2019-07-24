import { CustomerDemographic } from '../../../NorthwindModel/customerdemographic.interface';
import { Customer } from '../../../NorthwindModel/customer.interface';
import { Order } from '../../../NorthwindModel/order.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class CustomersService extends ODataEntityService<Customer> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Customers');
  }
  
  protected resolveEntityKey(entity: Partial<Customer>) {
    return entity.CustomerID;
  }
  
  public Orders(entity: Customer, options?): Observable<EntitySet<Order>> {
    return this.navigationProperty(entity, 'Orders', options)
        .pipe(map(resp => resp.toEntitySet<Order>()));
  }

  public addOrderToOrders(entity: Customer, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Orders', target, options);
  }

  public removeOrderFromOrders(entity: Customer, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Orders', target, options);
  }

  public CustomerDemographics(entity: Customer, options?): Observable<EntitySet<CustomerDemographic>> {
    return this.navigationProperty(entity, 'CustomerDemographics', options)
        .pipe(map(resp => resp.toEntitySet<CustomerDemographic>()));
  }

  public addCustomerDemographicToCustomerDemographics(entity: Customer, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'CustomerDemographics', target, options);
  }

  public removeCustomerDemographicFromCustomerDemographics(entity: Customer, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'CustomerDemographics', target, options);
  }
}