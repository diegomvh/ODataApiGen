import { NgModule } from '@angular/core';
import { TripPinService } from './trippinservice.service';
import { PhotosService } from './Microsoft/OData/SampleService/Models/TripPin/photos.service';
import { PeopleService } from './Microsoft/OData/SampleService/Models/TripPin/people.service';
import { AirlinesService } from './Microsoft/OData/SampleService/Models/TripPin/airlines.service';
import { AirportsService } from './Microsoft/OData/SampleService/Models/TripPin/airports.service';
import { MeService } from './Microsoft/OData/SampleService/Models/TripPin/me.service';


@NgModule({
  providers: [
    TripPinService,
    PhotosService,
    PeopleService,
    AirlinesService,
    AirportsService,
    MeService
  ]
})
export class TripPinModule { }