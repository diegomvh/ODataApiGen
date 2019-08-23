import { CustomerDemographic } from './customerdemographic.model';
import { Collection, ODataCollection } from 'angular-odata';

export class CustomerDemographicCollection extends ODataCollection<CustomerDemographic> {
  static type = 'NorthwindModel.CustomerDemographicCollection';
  static modelType = 'NorthwindModel.CustomerDemographic';
}