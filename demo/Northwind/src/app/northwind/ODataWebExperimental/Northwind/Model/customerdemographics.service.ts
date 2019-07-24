import { CustomerDemographic } from '../../../NorthwindModel/customerdemographic.interface';
import { Customer } from '../../../NorthwindModel/customer.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class CustomerDemographicsService extends ODataEntityService<CustomerDemographic> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'CustomerDemographics');
  }
  
  protected resolveEntityKey(entity: Partial<CustomerDemographic>) {
    return entity.CustomerTypeID;
  }
  
  public Customers(entity: CustomerDemographic, options?): Observable<EntitySet<Customer>> {
    return this.navigationProperty(entity, 'Customers', options)
        .pipe(map(resp => resp.toEntitySet<Customer>()));
  }

  public addCustomerToCustomers(entity: CustomerDemographic, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Customers', target, options);
  }

  public removeCustomerFromCustomers(entity: CustomerDemographic, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Customers', target, options);
  }
}