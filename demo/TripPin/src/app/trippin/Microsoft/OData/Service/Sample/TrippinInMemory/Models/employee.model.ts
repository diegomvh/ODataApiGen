import { Person, PersonCollection } from './person.model';
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class Employee extends Person {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Employee';
  static schema = Person.schema.extend({
    fields: [
      {name: 'Cost', type: 'Number', required: true, collection: false}
    ],
    relationships: [
      {name: 'Peers', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Person', required: false, collection: true}
    ],
    defaults: {}
  });
  Cost: number;
  Peers?: Person[];
}
export class EmployeeCollection extends ODataCollection<Employee> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Employee';
}