import { Region } from './region.model';
import { Collection, ODataCollection } from 'angular-odata';

export class RegionCollection extends ODataCollection<Region> {
  static type = 'NorthwindModel.RegionCollection';
  static model = 'NorthwindModel.Region';
}