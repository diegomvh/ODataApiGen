import { Person, PersonCollection } from './person.model';
import { Location, LocationCollection } from './location.model';
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const ManagerSchema = new ODataModelSchema({
  fields: [
    {name: 'Budget', type: 'number', required: true, length: 0, collection: false},
      {name: 'BossOffice', type: 'Location', required: false, length: 0, collection: false}
  ],
  relations: [
    {name: 'DirectReports', type: 'Person', required: false, length: 0, collection: true}
  ],
  defaults: {}
});

export class Manager extends Person {
  Budget: number;
  BossOffice?: Location;
  protected schema: ODataModelSchema = ManagerSchema;
}

export class ManagerCollection extends ODataCollection<Manager> {
}