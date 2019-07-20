import { Person, PersonCollection } from './person.model';
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const EmployeeSchema = new ODataModelSchema({
  fields: [
    {name: 'Cost', type: 'number', required: true, length: 0, collection: false}
  ],
  relations: [
    {name: 'Peers', type: 'Person', required: false, length: 0, collection: true}
  ],
  defaults: {}
});

export class Employee extends Person {
  Cost: number;
  protected schema: ODataModelSchema = EmployeeSchema;
}

export class EmployeeCollection extends ODataCollection<Employee> {
}