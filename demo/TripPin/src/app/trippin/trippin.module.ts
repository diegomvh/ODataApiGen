import { NgModule } from '@angular/core';

import { PeopleService } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/people.service';
import { AirlinesService } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/airlines.service';
import { AirportsService } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/airports.service';
import { NewComePeopleService } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/newcomepeople.service';

@NgModule({
  providers: [
    PeopleService,
    AirlinesService,
    AirportsService,
    NewComePeopleService
  ]
})
export class TripPinModule { }