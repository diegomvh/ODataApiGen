import { Person, PersonCollection } from './person.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataModelService, ODataContext, ODataQueryBase } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class PeopleService extends ODataModelService<Person, PersonCollection> {
  protected Model = Person;
  protected Collection = PersonCollection;

  constructor(
    protected http: HttpClient,
    protected context: ODataContext
  ) {
    super(http, context, 'People');
  }
  
  protected resolveEntityKey(entity) {
    return entity.UserName;
  }
  
  public Friends(entity: Person, options?) {
    return this.navigation(entity, 'Friends', options);
  }

  public addPersonToFriends(entity: Person, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Friends', target, options);
  }

  public removePersonFromFriends(entity: Person, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Friends', target, options);
  }

  public BestFriend(entity: Person, options?) {
    return this.property(entity, 'BestFriend', options);
  }

  public setPersonAsBestFriend(entity: Person, target: ODataQueryBase, options?) {
    return this.createRef(entity, 'BestFriend', target, options);
  }

  public unsetPersonAsBestFriend(entity: Person, target: ODataQueryBase, options?) {
    return this.deleteRef(entity, 'BestFriend', target, options);
  }

  public Trips(entity: Person, options?) {
    return this.navigation(entity, 'Trips', options);
  }

  public addTripToTrips(entity: Person, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Trips', target, options);
  }

  public removeTripFromTrips(entity: Person, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Trips', target, options);
  }
}