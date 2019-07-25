import { Territory } from './territory.model';
import { Collection, ODataCollection } from 'angular-odata';

export class TerritoryCollection extends ODataCollection<Territory> {
  static type = 'NorthwindModel.TerritoryCollection';
  static model = 'NorthwindModel.Territory';
}