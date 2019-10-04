import { PersonGender } from './Microsoft/OData/SampleService/Models/TripPin/persongender.enum';
import { City } from './Microsoft/OData/SampleService/Models/TripPin/city.interface';
import { Location } from './Microsoft/OData/SampleService/Models/TripPin/location.interface';
import { EventLocation } from './Microsoft/OData/SampleService/Models/TripPin/eventlocation.interface';
import { AirportLocation } from './Microsoft/OData/SampleService/Models/TripPin/airportlocation.interface';
import { Photo } from './Microsoft/OData/SampleService/Models/TripPin/photo.interface';
import { Person } from './Microsoft/OData/SampleService/Models/TripPin/person.interface';
import { Airline } from './Microsoft/OData/SampleService/Models/TripPin/airline.interface';
import { Airport } from './Microsoft/OData/SampleService/Models/TripPin/airport.interface';
import { PlanItem } from './Microsoft/OData/SampleService/Models/TripPin/planitem.interface';
import { PublicTransportation } from './Microsoft/OData/SampleService/Models/TripPin/publictransportation.interface';
import { Flight } from './Microsoft/OData/SampleService/Models/TripPin/flight.interface';
import { Event } from './Microsoft/OData/SampleService/Models/TripPin/event.interface';
import { Trip } from './Microsoft/OData/SampleService/Models/TripPin/trip.interface';


export const TripPinConfig = {
  baseUrl: 'https://services.odata.org/V4/TripPinServiceRW/',
  metadataUrl: 'https://services.odata.org/V4/TripPinServiceRW/$metadata',
  withCredentials: false,
  creation: '2019-10-03T21:40:19.8860391-03:00',
  version: '4.0'
}
