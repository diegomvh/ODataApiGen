import { Person, PersonCollection } from './person.model';
import { Location, LocationCollection } from './location.model';
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class Manager extends Person {
  Budget: number;
  BossOffice?: Location;
  private static _meta: ODataModelOptions<Manager> = new ODataModelOptions<Manager>({
    fields: [
      {name: 'Budget', type: 'number', required: true, length: 0, collection: false},
      {name: 'BossOffice', type: 'Location', required: false, length: 0, collection: false}
    ],
    relations: [
      {name: 'DirectReports', type: 'Person', required: false, length: 0, collection: true}
    ],
    defaults: {}
  });
  protected meta() { return Manager._meta; }
}

export class ManagerCollection extends ODataCollection<Manager> {
}