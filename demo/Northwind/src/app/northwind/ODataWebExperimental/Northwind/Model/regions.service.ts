import { Region } from '../../../NorthwindModel/region.interface';
import { Territory } from '../../../NorthwindModel/territory.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class RegionsService extends ODataEntityService<Region> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Regions');
  }
  
  protected resolveEntityKey(entity: Partial<Region>) {
    return entity.RegionID;
  }
  
  public Territories(entity: Region, options?): Observable<EntitySet<Territory>> {
    return this.navigationProperty(entity, 'Territories', options)
        .pipe(map(resp => resp.toEntitySet<Territory>()));
  }

  public addTerritoryToTerritories(entity: Region, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Territories', target, options);
  }

  public removeTerritoryFromTerritories(entity: Region, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Territories', target, options);
  }
}