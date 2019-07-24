import { Customer } from '../../../NorthwindModel/customer.interface';
import { Employee } from '../../../NorthwindModel/employee.interface';
import { Order_Detail } from '../../../NorthwindModel/order_detail.interface';
import { Order } from '../../../NorthwindModel/order.interface';
import { Shipper } from '../../../NorthwindModel/shipper.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class OrdersService extends ODataEntityService<Order> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Orders');
  }
  
  protected resolveEntityKey(entity: Partial<Order>) {
    return entity.OrderID;
  }
  
  public Customer(entity: Order, options?): Observable<Customer> {
    return this.navigationProperty(entity, 'Customer', options)
        .pipe(map(resp => resp.toEntity<Customer>()));
  }

  public setCustomerAsCustomer(entity: Order, target: ODataQueryBase, options?) {
    return this.createRef(entity, 'Customer', target, options);
  }

  public unsetCustomerAsCustomer(entity: Order, target: ODataQueryBase, options?) {
    return this.deleteRef(entity, 'Customer', target, options);
  }

  public Employee(entity: Order, options?): Observable<Employee> {
    return this.navigationProperty(entity, 'Employee', options)
        .pipe(map(resp => resp.toEntity<Employee>()));
  }

  public setEmployeeAsEmployee(entity: Order, target: ODataQueryBase, options?) {
    return this.createRef(entity, 'Employee', target, options);
  }

  public unsetEmployeeAsEmployee(entity: Order, target: ODataQueryBase, options?) {
    return this.deleteRef(entity, 'Employee', target, options);
  }

  public Order_Details(entity: Order, options?): Observable<EntitySet<Order_Detail>> {
    return this.navigationProperty(entity, 'Order_Details', options)
        .pipe(map(resp => resp.toEntitySet<Order_Detail>()));
  }

  public addOrder_DetailToOrder_Details(entity: Order, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Order_Details', target, options);
  }

  public removeOrder_DetailFromOrder_Details(entity: Order, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Order_Details', target, options);
  }

  public Shipper(entity: Order, options?): Observable<Shipper> {
    return this.navigationProperty(entity, 'Shipper', options)
        .pipe(map(resp => resp.toEntity<Shipper>()));
  }

  public setShipperAsShipper(entity: Order, target: ODataQueryBase, options?) {
    return this.createRef(entity, 'Shipper', target, options);
  }

  public unsetShipperAsShipper(entity: Order, target: ODataQueryBase, options?) {
    return this.deleteRef(entity, 'Shipper', target, options);
  }
}