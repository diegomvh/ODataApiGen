import { Injectable } from '@angular/core';

import { ODataModelService } from 'angular-odata';

import { Airline } from './airline.model';
import { AirlineCollection } from './airline.collection';


@Injectable()
export class AirlinesService extends ODataModelService<Airline, AirlineCollection> {
  static set: string = 'Airlines';
  static model = Airline;
  static collection = AirlineCollection;
  
}