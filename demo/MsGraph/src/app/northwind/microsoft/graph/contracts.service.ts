import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { contract } from './contract.interface';


@Injectable()
export class ContractsService extends ODataEntityService<contract> {
  static set: string = 'contracts';
  
  protected resolveEntityKey(entity: Partial<contract>) {
    return ;
  }
  // Actions
  
  // Functions
  
  // Navigations
  
}
