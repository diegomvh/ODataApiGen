import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { identityProvider } from './identityprovider.interface';


@Injectable()
export class IdentityProvidersService extends ODataEntityService<identityProvider> {
  static set: string = 'identityProviders';
  
  protected resolveEntityKey(entity: Partial<identityProvider>) {
    return entity.id;
  }
  // Actions
  
  // Functions
  
  // Navigations
  
}
