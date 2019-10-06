import { ODataModel, Schema } from 'angular-odata';

import { PersonGender } from './persongender.enum';
import { Location } from './location.model';
import { Photo } from './photo.model';
import { Trip } from './trip.model';
import { LocationCollection } from './location.collection';
import { PhotoCollection } from './photo.collection';
import { PersonCollection } from './person.collection';
import { TripCollection } from './trip.collection';

export class Person extends ODataModel {
  static schema = Schema.create({ 
    keys: [
      {name: 'UserName'}
    ],
    fields: [
      {name: 'UserName', type: 'String', required: true},
      {name: 'FirstName', type: 'String', required: true},
      {name: 'LastName', type: 'String', required: true},
      {name: 'Emails', type: 'String', required: true, collection: true},
      {name: 'AddressInfo', type: 'Microsoft.OData.SampleService.Models.TripPin.LocationCollection', required: true, collection: true},
      {name: 'Gender', type: 'Microsoft.OData.SampleService.Models.TripPin.PersonGender', required: true},
      {name: 'Concurrency', type: 'Number', required: true},
      {name: 'Friends', type: 'Microsoft.OData.SampleService.Models.TripPin.PersonCollection', navigation: true, collection: true},
      {name: 'Trips', type: 'Microsoft.OData.SampleService.Models.TripPin.TripCollection', navigation: true, collection: true},
      {name: 'Photo', type: 'Microsoft.OData.SampleService.Models.TripPin.Photo', navigation: true}
    ]
  });
  UserName: string;
  FirstName: string;
  LastName: string;
  Emails: string[];
  AddressInfo: LocationCollection;
  Gender: PersonGender;
  Concurrency: number;
  Friends?: PersonCollection;
  Trips?: TripCollection;
  Photo?: Photo
}