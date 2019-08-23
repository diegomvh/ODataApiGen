import { PersonGender } from './persongender.enum';
import { Feature } from './feature.enum';
import { Location } from './location.model';
import { Trip, TripCollection } from './trip.model';
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class Person extends ODataModel {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Person';
  static schema = Schema.create({
    fields: [
      {name: 'UserName', type: 'String', required: true, collection: false},
      {name: 'FirstName', type: 'String', required: true, collection: false},
      {name: 'LastName', type: 'String', required: true, collection: false},
      {name: 'MiddleName', type: 'String', required: true, collection: false},
      {name: 'Gender', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.PersonGender', required: true, collection: false},
      {name: 'Age', type: 'Number', required: true, collection: false},
      {name: 'Emails', type: 'String', required: true, collection: true},
      {name: 'AddressInfo', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Location', required: true, collection: true},
      {name: 'HomeAddress', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Location', required: true, collection: false},
      {name: 'FavoriteFeature', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Feature', required: true, collection: false},
      {name: 'Features', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Feature', required: true, collection: true}
    ],
    relationships: [
      {name: 'Friends', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Person', required: false, collection: true},
      {name: 'BestFriend', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Person', required: false, collection: false},
      {name: 'Trips', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Trip', required: false, collection: true}
    ],
    defaults: {}
  });
  UserName: string;
  FirstName: string;
  LastName: string;
  MiddleName: string;
  Gender: PersonGender;
  Age: number;
  Emails: string[];
  AddressInfo: Location[];
  HomeAddress: Location;
  FavoriteFeature: Feature;
  Features: Feature[];
  Friends?: Person[];
  BestFriend?: Person;
  Trips?: Trip[];
}
export class PersonCollection extends ODataCollection<Person> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Person';
}