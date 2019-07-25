import { Territory } from './territory.model';
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Region extends ODataModel {
  static type = 'NorthwindModel.Region';
  static schema = Schema.create({
    keys: [
        'RegionID'
    ],
    fields: [
      {name: 'RegionID', required: true, type: 'Number'},
      {name: 'RegionDescription', required: true, type: 'String', length: 50},
      {name: 'Territories', required: false, type: 'NorthwindModel.TerritoryCollection'}
    ],
    defaults: {}
  });
  RegionID: number;
  RegionDescription: string;

  public getTerritories(): ODataCollection<Territory> {
    return this.relatedODataCollection('Territories') as ODataCollection<Territory>;
  }
  public addTerritoryToTerritories(target: ODataQueryBase, options?) {
    return this.createODataCollectionRef('Territories', target, options);
  }
  public removeTerritoryFromTerritories(target: ODataQueryBase, options?) {
    return this.deleteODataCollectionRef('Territories', target, options);
  }
}