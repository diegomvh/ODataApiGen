import { Person, PersonCollection } from './person.model';
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class Employee extends Person {
  Cost: number;
  private static _meta: ODataModelOptions<Employee> = new ODataModelOptions<Employee>({
    fields: [
      {name: 'Cost', type: 'number', required: true, length: 0, collection: false}
    ],
    relations: [
      {name: 'Peers', type: 'Person', required: false, length: 0, collection: true}
    ],
    defaults: {}
  });
  protected meta() { return Employee._meta; }
}

export class EmployeeCollection extends ODataCollection<Employee> {
}