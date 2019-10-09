import { ODataConfig } from 'angular-odata';

import { PersonGender } from './Microsoft/OData/SampleService/Models/TripPin/persongender.enum';
import { City } from './Microsoft/OData/SampleService/Models/TripPin/city.model';
import { Location } from './Microsoft/OData/SampleService/Models/TripPin/location.model';
import { EventLocation } from './Microsoft/OData/SampleService/Models/TripPin/eventlocation.model';
import { AirportLocation } from './Microsoft/OData/SampleService/Models/TripPin/airportlocation.model';
import { Photo } from './Microsoft/OData/SampleService/Models/TripPin/photo.model';
import { Person } from './Microsoft/OData/SampleService/Models/TripPin/person.model';
import { Airline } from './Microsoft/OData/SampleService/Models/TripPin/airline.model';
import { Airport } from './Microsoft/OData/SampleService/Models/TripPin/airport.model';
import { PlanItem } from './Microsoft/OData/SampleService/Models/TripPin/planitem.model';
import { PublicTransportation } from './Microsoft/OData/SampleService/Models/TripPin/publictransportation.model';
import { Flight } from './Microsoft/OData/SampleService/Models/TripPin/flight.model';
import { Event } from './Microsoft/OData/SampleService/Models/TripPin/event.model';
import { Trip } from './Microsoft/OData/SampleService/Models/TripPin/trip.model';
import { CityCollection } from './Microsoft/OData/SampleService/Models/TripPin/city.collection';
import { LocationCollection } from './Microsoft/OData/SampleService/Models/TripPin/location.collection';
import { EventLocationCollection } from './Microsoft/OData/SampleService/Models/TripPin/eventlocation.collection';
import { AirportLocationCollection } from './Microsoft/OData/SampleService/Models/TripPin/airportlocation.collection';
import { PhotoCollection } from './Microsoft/OData/SampleService/Models/TripPin/photo.collection';
import { PersonCollection } from './Microsoft/OData/SampleService/Models/TripPin/person.collection';
import { AirlineCollection } from './Microsoft/OData/SampleService/Models/TripPin/airline.collection';
import { AirportCollection } from './Microsoft/OData/SampleService/Models/TripPin/airport.collection';
import { PlanItemCollection } from './Microsoft/OData/SampleService/Models/TripPin/planitem.collection';
import { PublicTransportationCollection } from './Microsoft/OData/SampleService/Models/TripPin/publictransportation.collection';
import { FlightCollection } from './Microsoft/OData/SampleService/Models/TripPin/flight.collection';
import { EventCollection } from './Microsoft/OData/SampleService/Models/TripPin/event.collection';
import { TripCollection } from './Microsoft/OData/SampleService/Models/TripPin/trip.collection';

export const TripPinConfig: ODataConfig = {
  baseUrl: 'https://services.odata.org/V4/TripPinServiceRW/',
  metadataUrl: 'https://services.odata.org/V4/TripPinServiceRW/$metadata',
  withCredentials: false,
  creation: new Date('2019-10-08T22:10:30.8735357-03:00'),
  version: '4.0',
  enums: {
    'Microsoft.OData.SampleService.Models.TripPin.PersonGender': PersonGender
  },
  models: {
    'Microsoft.OData.SampleService.Models.TripPin.City': City,
    'Microsoft.OData.SampleService.Models.TripPin.Location': Location,
    'Microsoft.OData.SampleService.Models.TripPin.EventLocation': EventLocation,
    'Microsoft.OData.SampleService.Models.TripPin.AirportLocation': AirportLocation,
    'Microsoft.OData.SampleService.Models.TripPin.Photo': Photo,
    'Microsoft.OData.SampleService.Models.TripPin.Person': Person,
    'Microsoft.OData.SampleService.Models.TripPin.Airline': Airline,
    'Microsoft.OData.SampleService.Models.TripPin.Airport': Airport,
    'Microsoft.OData.SampleService.Models.TripPin.PlanItem': PlanItem,
    'Microsoft.OData.SampleService.Models.TripPin.PublicTransportation': PublicTransportation,
    'Microsoft.OData.SampleService.Models.TripPin.Flight': Flight,
    'Microsoft.OData.SampleService.Models.TripPin.Event': Event,
    'Microsoft.OData.SampleService.Models.TripPin.Trip': Trip
  },
  collections: {
    'Microsoft.OData.SampleService.Models.TripPin.CityCollection': CityCollection,
    'Microsoft.OData.SampleService.Models.TripPin.LocationCollection': LocationCollection,
    'Microsoft.OData.SampleService.Models.TripPin.EventLocationCollection': EventLocationCollection,
    'Microsoft.OData.SampleService.Models.TripPin.AirportLocationCollection': AirportLocationCollection,
    'Microsoft.OData.SampleService.Models.TripPin.PhotoCollection': PhotoCollection,
    'Microsoft.OData.SampleService.Models.TripPin.PersonCollection': PersonCollection,
    'Microsoft.OData.SampleService.Models.TripPin.AirlineCollection': AirlineCollection,
    'Microsoft.OData.SampleService.Models.TripPin.AirportCollection': AirportCollection,
    'Microsoft.OData.SampleService.Models.TripPin.PlanItemCollection': PlanItemCollection,
    'Microsoft.OData.SampleService.Models.TripPin.PublicTransportationCollection': PublicTransportationCollection,
    'Microsoft.OData.SampleService.Models.TripPin.FlightCollection': FlightCollection,
    'Microsoft.OData.SampleService.Models.TripPin.EventCollection': EventCollection,
    'Microsoft.OData.SampleService.Models.TripPin.TripCollection': TripCollection
  }
}