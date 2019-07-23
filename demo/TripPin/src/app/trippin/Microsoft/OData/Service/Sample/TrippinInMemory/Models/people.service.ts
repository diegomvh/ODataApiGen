import { PersonGender } from './persongender.enum';
import { Feature } from './feature.enum';
import { Location } from './location.model';
import { Person, PersonCollection } from './person.model';
import { Trip, TripCollection } from './trip.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class PeopleService extends ODataModelService<Person, PersonCollection> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Person';
  static collection = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.PersonCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'People');
  }
  
  protected resolveEntityKey(entity: Partial<Person>) {
    return entity.UserName;
  }
  
  model(attrs: any): Person {
    return super.model(attrs) as Person;
  }

  collection(attrs: any): PersonCollection {
    return super.collection(attrs) as PersonCollection;
  }

  public Friends(entity: Person, options?): Observable<EntitySet<Person>> {
    return this.navigationProperty<Person>(entity, 'Friends', options);
  }

  public addPersonToFriends(entity: Person, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Friends', target, options);
  }

  public removePersonFromFriends(entity: Person, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Friends', target, options);
  }

  public BestFriend(entity: Person, options?): Observable<Person> {
    return this.property<Person>(entity, 'BestFriend', options);
  }

  public setPersonAsBestFriend(entity: Person, target: ODataQueryBase, options?) {
    return this.createRef(entity, 'BestFriend', target, options);
  }

  public unsetPersonAsBestFriend(entity: Person, target: ODataQueryBase, options?) {
    return this.deleteRef(entity, 'BestFriend', target, options);
  }

  public Trips(entity: Person, options?): Observable<EntitySet<Trip>> {
    return this.navigationProperty<Trip>(entity, 'Trips', options);
  }

  public addTripToTrips(entity: Person, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Trips', target, options);
  }

  public removeTripFromTrips(entity: Person, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Trips', target, options);
  }
}