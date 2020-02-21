import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityAnnotations, ODataCollectionAnnotations, ODataPropertyAnnotations, ODataEntityResource } from 'angular-odata';

import { Airline } from './airline.entity';


@Injectable()
export class AirlinesService extends ODataEntityService<Airline> {
  static path: string = 'Airlines';
  static type: string = 'Microsoft.OData.SampleService.Models.TripPin.Airline';
  
  // Actions
  
  // Functions
  
  // Navigations
  
}
