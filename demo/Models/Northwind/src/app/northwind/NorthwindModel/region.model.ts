import { Territory } from './territory.model';
import { TerritoryCollection } from './territory.collection';
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Region extends ODataModel {
  static type = 'NorthwindModel.Region';
  static schema = Schema.create({
    keys: [
      {name: 'RegionID'}
    ],
    fields: [
      {name: 'RegionID', type: 'Number', required: true},
      {name: 'RegionDescription', type: 'String', required: true, length: 50},
      {name: 'Territories', type: 'NorthwindModel.TerritoryCollection', ctor: true, related: true, collection: true}
    ]
  });
  RegionID: number;
  RegionDescription: string;
  Territories?: TerritoryCollection;

  
}