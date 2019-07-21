import { Location, LocationCollection } from './location.model';
import { Person, PersonCollection } from './person.model';
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class Manager extends Person {
  static schema = Od2Ts.Angular.Model.schema.extend({
    fields: [
      {name: 'Budget', type: 'number', constructor: Number, required: true, collection: false},
      {name: 'BossOffice', type: 'Location', constructor: Location, required: true, collection: false}
    ],
    relationships: [
      {name: 'DirectReports', type: 'Person', constructor: Person, required: false, collection: true}
    ],
    defaults: {}
  });
  Budget: number;
  BossOffice: Location;
}
export class ManagerCollection extends ODataCollection<Manager> {
  static Model = Manager;
}