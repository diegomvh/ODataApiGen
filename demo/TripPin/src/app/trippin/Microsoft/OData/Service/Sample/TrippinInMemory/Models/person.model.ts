import { PersonGender } from './persongender.enum';
import { Feature } from './feature.enum';
import { Trip, TripCollection } from './trip.model';
import { Location, LocationCollection } from './location.model';
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class Person extends ODataModel {
  UserName: string;
  FirstName: string;
  LastName?: string;
  MiddleName?: string;
  Gender: PersonGender;
  Age?: number;
  Emails?: string;
  AddressInfo?: Location;
  HomeAddress?: Location;
  FavoriteFeature: Feature;
  Features: Feature;
  private static _meta: ODataModelOptions<Person> = new ODataModelOptions<Person>({
    fields: [
      {name: 'UserName', type: 'string', required: true, length: 0, collection: false},
      {name: 'FirstName', type: 'string', required: true, length: 0, collection: false},
      {name: 'LastName', type: 'string', required: false, length: 0, collection: false},
      {name: 'MiddleName', type: 'string', required: false, length: 0, collection: false},
      {name: 'Gender', type: 'PersonGender', required: true, length: 0, collection: false},
      {name: 'Age', type: 'number', required: false, length: 0, collection: false},
      {name: 'Emails', type: 'string', required: false, length: 0, collection: true},
      {name: 'AddressInfo', type: 'Location', required: false, length: 0, collection: true},
      {name: 'HomeAddress', type: 'Location', required: false, length: 0, collection: false},
      {name: 'FavoriteFeature', type: 'Feature', required: true, length: 0, collection: false},
      {name: 'Features', type: 'Feature', required: true, length: 0, collection: true}
    ],
    relations: [
      {name: 'Friends', type: 'Person', required: false, length: 0, collection: true},
      {name: 'BestFriend', type: 'Person', required: false, length: 0, collection: false},
      {name: 'Trips', type: 'Trip', required: false, length: 0, collection: true}
    ],
    defaults: {}
  });
  protected meta() { return Person._meta; }
}

export class PersonCollection extends ODataCollection<Person> {
}