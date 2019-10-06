import { Injectable } from '@angular/core';

import { ODataModelService } from 'angular-odata';

import { PersonGender } from './persongender.enum';
import { Location } from './location.model';
import { Photo } from './photo.model';
import { Person } from './person.model';
import { Trip } from './trip.model';
import { LocationCollection } from './location.collection';
import { PhotoCollection } from './photo.collection';
import { PersonCollection } from './person.collection';
import { TripCollection } from './trip.collection';


@Injectable()
export class PeopleService extends ODataModelService<Person, PersonCollection> {
  static set: string = 'People';
  static model = Person;
  static collection = PersonCollection;
  
}