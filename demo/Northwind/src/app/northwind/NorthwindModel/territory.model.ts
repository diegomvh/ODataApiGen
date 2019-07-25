import { Employee } from './employee.model';
import { Region } from './region.model';
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Territory extends ODataModel {
  static type = 'NorthwindModel.Territory';
  static schema = Schema.create({
    keys: [
        'TerritoryID'
    ],
    fields: [
      {name: 'TerritoryID', required: true, type: 'String', length: 20},
      {name: 'TerritoryDescription', required: true, type: 'String', length: 50},
      {name: 'RegionID', required: true, type: 'Number'},
      {name: 'Region', required: false, type: 'NorthwindModel.Region'},
      {name: 'Employees', required: false, type: 'NorthwindModel.EmployeeCollection'}
    ],
    defaults: {}
  });
  TerritoryID: string;
  TerritoryDescription: string;
  RegionID: number;

  public getRegion(): Region {
    return this.relatedODataModel('Region') as Region;
  }
  public setRegionAsRegion(target: ODataQueryBase, options?) {
    return this.createODataModelRef('Region', target, options);
  }
  public unsetRegionAsRegion(target: ODataQueryBase, options?) {
    return this.deleteODataModelRef('Region', target, options);
  }
  public getEmployees(): ODataCollection<Employee> {
    return this.relatedODataCollection('Employees') as ODataCollection<Employee>;
  }
  public addEmployeeToEmployees(target: ODataQueryBase, options?) {
    return this.createODataCollectionRef('Employees', target, options);
  }
  public removeEmployeeFromEmployees(target: ODataQueryBase, options?) {
    return this.deleteODataCollectionRef('Employees', target, options);
  }
}