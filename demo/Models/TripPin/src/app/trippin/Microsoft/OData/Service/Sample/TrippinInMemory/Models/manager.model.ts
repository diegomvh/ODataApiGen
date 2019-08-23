import { Location } from './location.model';
import { Person, PersonCollection } from './person.model';
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class Manager extends Person {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Manager';
  static schema = Person.schema.extend({
    fields: [
      {name: 'Budget', type: 'Number', required: true, collection: false},
      {name: 'BossOffice', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Location', required: true, collection: false}
    ],
    relationships: [
      {name: 'DirectReports', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Person', required: false, collection: true}
    ],
    defaults: {}
  });
  Budget: number;
  BossOffice: Location;
  DirectReports?: Person[];
}
export class ManagerCollection extends ODataCollection<Manager> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Manager';
}