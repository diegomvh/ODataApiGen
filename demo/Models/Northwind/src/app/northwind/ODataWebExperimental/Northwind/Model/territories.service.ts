import { Employee } from '../../../NorthwindModel/employee.model';
import { Region } from '../../../NorthwindModel/region.model';
import { Territory } from '../../../NorthwindModel/territory.model';
import { EmployeeCollection } from '../../../NorthwindModel/employee.collection';
import { RegionCollection } from '../../../NorthwindModel/region.collection';
import { TerritoryCollection } from '../../../NorthwindModel/territory.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class TerritoriesService extends ODataModelService {
  static modelType = 'NorthwindModel.Territory';
  static collectionType = 'NorthwindModel.TerritoryCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Territories');
  }
  
  model(attrs?: any): Territory {
    return super.model(attrs) as Territory;
  }

  collection(attrs?: any): TerritoryCollection {
    return super.collection(attrs) as TerritoryCollection;
  }
}