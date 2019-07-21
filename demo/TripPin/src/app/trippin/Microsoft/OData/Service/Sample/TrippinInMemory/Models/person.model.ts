import { PersonGender } from './persongender.enum';
import { Feature } from './feature.enum';
import { Location, LocationCollection } from './location.model';
import { Trip, TripCollection } from './trip.model';
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class Person extends ODataModel {
  static schema = Schema.create({
    fields: [
      {name: 'UserName', type: 'string', constructor: String, required: true, collection: false},
      {name: 'FirstName', type: 'string', constructor: String, required: true, collection: false},
      {name: 'LastName', type: 'string', constructor: String, required: true, collection: false},
      {name: 'MiddleName', type: 'string', constructor: String, required: true, collection: false},
      {name: 'Gender', type: 'PersonGender', constructor: PersonGender, required: true, collection: false},
      {name: 'Age', type: 'number', constructor: Number, required: true, collection: false},
      {name: 'Emails', type: 'string', constructor: String, required: true, collection: true},
      {name: 'AddressInfo', type: 'Location', constructor: Location, required: true, collection: true},
      {name: 'HomeAddress', type: 'Location', constructor: Location, required: true, collection: false},
      {name: 'FavoriteFeature', type: 'Feature', constructor: Feature, required: true, collection: false},
      {name: 'Features', type: 'Feature', constructor: Feature, required: true, collection: true}
    ],
    relationships: [
      {name: 'Friends', type: 'Person', constructor: Person, required: false, collection: true},
      {name: 'BestFriend', type: 'Person', constructor: Person, required: false, collection: false},
      {name: 'Trips', type: 'Trip', constructor: Trip, required: false, collection: true}
    ],
    defaults: {}
  });
  UserName: string;
  FirstName: string;
  LastName: string;
  MiddleName: string;
  Gender: PersonGender;
  Age: number;
  Emails: string;
  AddressInfo: Location;
  HomeAddress: Location;
  FavoriteFeature: Feature;
  Features: Feature;
}
export class PersonCollection extends ODataCollection<Person> {
  static Model = Person;
}