import { Employee } from '../../../NorthwindModel/employee.model';
import { Order } from '../../../NorthwindModel/order.model';
import { Territory } from '../../../NorthwindModel/territory.model';
import { EmployeeCollection } from '../../../NorthwindModel/employee.collection';
import { OrderCollection } from '../../../NorthwindModel/order.collection';
import { TerritoryCollection } from '../../../NorthwindModel/territory.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class EmployeesService extends ODataModelService {
  static modelType = 'NorthwindModel.Employee';
  static collectionType = 'NorthwindModel.EmployeeCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Employees');
  }
  
  model(attrs?: any): Employee {
    return super.model(attrs) as Employee;
  }

  collection(attrs?: any): EmployeeCollection {
    return super.collection(attrs) as EmployeeCollection;
  }
}