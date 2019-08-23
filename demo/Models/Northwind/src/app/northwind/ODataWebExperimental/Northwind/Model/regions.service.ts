import { Region } from '../../../NorthwindModel/region.model';
import { Territory } from '../../../NorthwindModel/territory.model';
import { RegionCollection } from '../../../NorthwindModel/region.collection';
import { TerritoryCollection } from '../../../NorthwindModel/territory.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class RegionsService extends ODataModelService {
  static modelType = 'NorthwindModel.Region';
  static collectionType = 'NorthwindModel.RegionCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Regions');
  }
  
  model(attrs?: any): Region {
    return super.model(attrs) as Region;
  }

  collection(attrs?: any): RegionCollection {
    return super.collection(attrs) as RegionCollection;
  }
}