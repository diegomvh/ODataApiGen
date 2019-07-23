import { Location } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/location.model';
import { City } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/city.model';
import { AirportLocation } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/airportlocation.model';
import { EventLocation } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/eventlocation.model';
import { Person, PersonCollection } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/person.model';
import { Airline, AirlineCollection } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/airline.model';
import { Airport, AirportCollection } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/airport.model';
import { Trip, TripCollection } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/trip.model';
import { PlanItem, PlanItemCollection } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/planitem.model';
import { Event, EventCollection } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/event.model';
import { PublicTransportation, PublicTransportationCollection } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/publictransportation.model';
import { Flight, FlightCollection } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/flight.model';
import { Employee, EmployeeCollection } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/employee.model';
import { Manager, ManagerCollection } from './Microsoft/OData/Service/Sample/TrippinInMemory/Models/manager.model';
export const TripPinConfig = {
  baseUrl: 'https://services.odata.org/TripPinRESTierService/',
  metadataUrl: 'https://services.odata.org/TripPinRESTierService/$metadata',
  withCredentials: true,
  creation: new Date('2019-07-22T21:53:39.6433788-03:00'),
  version: '4.0',
  models: {
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Location': Location,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.City': City,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.AirportLocation': AirportLocation,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.EventLocation': EventLocation,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Person': Person,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Airline': Airline,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Airport': Airport,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Trip': Trip,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.PlanItem': PlanItem,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Event': Event,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.PublicTransportation': PublicTransportation,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Flight': Flight,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Employee': Employee,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Manager': Manager
  },
  collections: {
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.PersonCollection': PersonCollection,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.AirlineCollection': AirlineCollection,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.AirportCollection': AirportCollection,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.TripCollection': TripCollection,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.PlanItemCollection': PlanItemCollection,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.EventCollection': EventCollection,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.PublicTransportationCollection': PublicTransportationCollection,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.FlightCollection': FlightCollection,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.EmployeeCollection': EmployeeCollection,
    'Microsoft.OData.Service.Sample.TrippinInMemory.Models.ManagerCollection': ManagerCollection
  }
}