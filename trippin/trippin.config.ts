import { ODataConfig } from 'angular-odata';

import { PersonGender } from './Microsoft/OData/SampleService/Models/TripPin/persongender.enum';
import { City } from './Microsoft/OData/SampleService/Models/TripPin/city.entity';
import { Location } from './Microsoft/OData/SampleService/Models/TripPin/location.entity';
import { EventLocation } from './Microsoft/OData/SampleService/Models/TripPin/eventlocation.entity';
import { AirportLocation } from './Microsoft/OData/SampleService/Models/TripPin/airportlocation.entity';
import { Photo } from './Microsoft/OData/SampleService/Models/TripPin/photo.entity';
import { Person } from './Microsoft/OData/SampleService/Models/TripPin/person.entity';
import { Airline } from './Microsoft/OData/SampleService/Models/TripPin/airline.entity';
import { Airport } from './Microsoft/OData/SampleService/Models/TripPin/airport.entity';
import { PlanItem } from './Microsoft/OData/SampleService/Models/TripPin/planitem.entity';
import { PublicTransportation } from './Microsoft/OData/SampleService/Models/TripPin/publictransportation.entity';
import { Flight } from './Microsoft/OData/SampleService/Models/TripPin/flight.entity';
import { Event } from './Microsoft/OData/SampleService/Models/TripPin/event.entity';
import { Trip } from './Microsoft/OData/SampleService/Models/TripPin/trip.entity';
import { CitySchema } from './Microsoft/OData/SampleService/Models/TripPin/city.schema';
import { LocationSchema } from './Microsoft/OData/SampleService/Models/TripPin/location.schema';
import { EventLocationSchema } from './Microsoft/OData/SampleService/Models/TripPin/eventlocation.schema';
import { AirportLocationSchema } from './Microsoft/OData/SampleService/Models/TripPin/airportlocation.schema';
import { PhotoSchema } from './Microsoft/OData/SampleService/Models/TripPin/photo.schema';
import { PersonSchema } from './Microsoft/OData/SampleService/Models/TripPin/person.schema';
import { AirlineSchema } from './Microsoft/OData/SampleService/Models/TripPin/airline.schema';
import { AirportSchema } from './Microsoft/OData/SampleService/Models/TripPin/airport.schema';
import { PlanItemSchema } from './Microsoft/OData/SampleService/Models/TripPin/planitem.schema';
import { PublicTransportationSchema } from './Microsoft/OData/SampleService/Models/TripPin/publictransportation.schema';
import { FlightSchema } from './Microsoft/OData/SampleService/Models/TripPin/flight.schema';
import { EventSchema } from './Microsoft/OData/SampleService/Models/TripPin/event.schema';
import { TripSchema } from './Microsoft/OData/SampleService/Models/TripPin/trip.schema';

export const TripPinConfig: ODataConfig = {
  baseUrl: 'https://services.odata.org/V4/TripPinServiceRW/',
  metadataUrl: 'https://services.odata.org/V4/TripPinServiceRW/$metadata',
  withCredentials: false,
  stringAsEnum: false,
  creation: new Date('2020-02-20T23:25:08.3515129-03:00'),
  version: '4.0',
  enums: {
    'Microsoft.OData.SampleService.Models.TripPin.PersonGender': PersonGender},
  models: {
    },
  collections: {
    },
  schemas: {
    'Microsoft.OData.SampleService.Models.TripPin.City': CitySchema,
    'Microsoft.OData.SampleService.Models.TripPin.Location': LocationSchema,
    'Microsoft.OData.SampleService.Models.TripPin.EventLocation': EventLocationSchema,
    'Microsoft.OData.SampleService.Models.TripPin.AirportLocation': AirportLocationSchema,
    'Microsoft.OData.SampleService.Models.TripPin.Photo': PhotoSchema,
    'Microsoft.OData.SampleService.Models.TripPin.Person': PersonSchema,
    'Microsoft.OData.SampleService.Models.TripPin.Airline': AirlineSchema,
    'Microsoft.OData.SampleService.Models.TripPin.Airport': AirportSchema,
    'Microsoft.OData.SampleService.Models.TripPin.PlanItem': PlanItemSchema,
    'Microsoft.OData.SampleService.Models.TripPin.PublicTransportation': PublicTransportationSchema,
    'Microsoft.OData.SampleService.Models.TripPin.Flight': FlightSchema,
    'Microsoft.OData.SampleService.Models.TripPin.Event': EventSchema,
    'Microsoft.OData.SampleService.Models.TripPin.Trip': TripSchema}
}