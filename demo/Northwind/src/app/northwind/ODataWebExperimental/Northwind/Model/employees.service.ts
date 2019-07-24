import { Employee } from '../../../NorthwindModel/employee.interface';
import { Order } from '../../../NorthwindModel/order.interface';
import { Territory } from '../../../NorthwindModel/territory.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class EmployeesService extends ODataEntityService<Employee> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Employees');
  }
  
  protected resolveEntityKey(entity: Partial<Employee>) {
    return entity.EmployeeID;
  }
  
  public Employees1(entity: Employee, options?): Observable<EntitySet<Employee>> {
    return this.navigationProperty(entity, 'Employees1', options)
        .pipe(map(resp => resp.toEntitySet<Employee>()));
  }

  public addEmployeeToEmployees1(entity: Employee, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Employees1', target, options);
  }

  public removeEmployeeFromEmployees1(entity: Employee, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Employees1', target, options);
  }

  public Employee1(entity: Employee, options?): Observable<Employee> {
    return this.navigationProperty(entity, 'Employee1', options)
        .pipe(map(resp => resp.toEntity<Employee>()));
  }

  public setEmployeeAsEmployee1(entity: Employee, target: ODataQueryBase, options?) {
    return this.createRef(entity, 'Employee1', target, options);
  }

  public unsetEmployeeAsEmployee1(entity: Employee, target: ODataQueryBase, options?) {
    return this.deleteRef(entity, 'Employee1', target, options);
  }

  public Orders(entity: Employee, options?): Observable<EntitySet<Order>> {
    return this.navigationProperty(entity, 'Orders', options)
        .pipe(map(resp => resp.toEntitySet<Order>()));
  }

  public addOrderToOrders(entity: Employee, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Orders', target, options);
  }

  public removeOrderFromOrders(entity: Employee, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Orders', target, options);
  }

  public Territories(entity: Employee, options?): Observable<EntitySet<Territory>> {
    return this.navigationProperty(entity, 'Territories', options)
        .pipe(map(resp => resp.toEntitySet<Territory>()));
  }

  public addTerritoryToTerritories(entity: Employee, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Territories', target, options);
  }

  public removeTerritoryFromTerritories(entity: Employee, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Territories', target, options);
  }
}