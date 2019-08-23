import { Employee } from '../../../NorthwindModel/employee.interface';
import { Region } from '../../../NorthwindModel/region.interface';
import { Territory } from '../../../NorthwindModel/territory.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class TerritoriesService extends ODataEntityService<Territory> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Territories');
  }
  
  protected resolveEntityKey(entity: Partial<Territory>) {
    return entity.TerritoryID;
  }
  
  public Region(entity: Territory, options?): Observable<Region> {
    return this.navigationProperty(entity, 'Region', options)
        .pipe(map(resp => resp.toEntity<Region>()));
  }

  public setRegionAsRegion(entity: Territory, target: ODataQueryBase, options?) {
    return this.createRef(entity, 'Region', target, options);
  }

  public unsetRegionAsRegion(entity: Territory, target: ODataQueryBase, options?) {
    return this.deleteRef(entity, 'Region', target, options);
  }

  public Employees(entity: Territory, options?): Observable<EntitySet<Employee>> {
    return this.navigationProperty(entity, 'Employees', options)
        .pipe(map(resp => resp.toEntitySet<Employee>()));
  }

  public addEmployeeToEmployees(entity: Territory, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Employees', target, options);
  }

  public removeEmployeeFromEmployees(entity: Territory, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Employees', target, options);
  }
}