import { Injectable } from '@angular/core';

import { ODataModelService } from 'angular-odata';

import { AirportLocation } from './airportlocation.model';
import { Airport } from './airport.model';
import { AirportLocationCollection } from './airportlocation.collection';
import { AirportCollection } from './airport.collection';


@Injectable()
export class AirportsService extends ODataModelService<Airport, AirportCollection> {
  static set: string = 'Airports';
  static model = Airport;
  static collection = AirportCollection;
  
}