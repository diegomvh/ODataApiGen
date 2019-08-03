import { Employee } from './employee.model';
import { Region } from './region.model';
import { EmployeeCollection } from './employee.collection';
import { RegionCollection } from './region.collection';
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Territory extends ODataModel {
  static type = 'NorthwindModel.Territory';
  static schema = Schema.create({
    keys: [
      {name: 'TerritoryID'}
    ],
    fields: [
      {name: 'TerritoryID', type: 'String', required: true, length: 20},
      {name: 'TerritoryDescription', type: 'String', required: true, length: 50},
      {name: 'RegionID', type: 'Number', required: true},
      {name: 'Region', type: 'NorthwindModel.Region', ctor: true, related: true},
      {name: 'Employees', type: 'NorthwindModel.EmployeeCollection', ctor: true, related: true, collection: true}
    ]
  });
  TerritoryID: string;
  TerritoryDescription: string;
  RegionID: number;
  Region?: Region;
  Employees?: EmployeeCollection;

  
}