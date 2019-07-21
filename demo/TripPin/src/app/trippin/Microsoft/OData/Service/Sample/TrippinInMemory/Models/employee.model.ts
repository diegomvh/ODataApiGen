import { Person, PersonCollection } from './person.model';
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class Employee extends Person {
  static schema = Od2Ts.Angular.Model.schema.extend({
    fields: [
      {name: 'Cost', type: 'number', constructor: Number, required: true, collection: false}
    ],
    relationships: [
      {name: 'Peers', type: 'Person', constructor: Person, required: false, collection: true}
    ],
    defaults: {}
  });
  Cost: number;
}
export class EmployeeCollection extends ODataCollection<Employee> {
  static Model = Employee;
}