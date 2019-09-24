import { NgModule } from '@angular/core';

import { PhotosService } from './Microsoft/OData/SampleService/Models/TripPin/photos.service';
import { PeopleService } from './Microsoft/OData/SampleService/Models/TripPin/people.service';
import { AirlinesService } from './Microsoft/OData/SampleService/Models/TripPin/airlines.service';
import { AirportsService } from './Microsoft/OData/SampleService/Models/TripPin/airports.service';

@NgModule({
  providers: [
    PhotosService,
    PeopleService,
    AirlinesService,
    AirportsService
  ]
})
export class TripPinModule { }