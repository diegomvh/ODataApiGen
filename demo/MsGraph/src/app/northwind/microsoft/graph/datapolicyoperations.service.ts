import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { dataPolicyOperationStatus } from './datapolicyoperationstatus.enum';
import { dataPolicyOperation } from './datapolicyoperation.interface';


@Injectable()
export class DataPolicyOperationsService extends ODataEntityService<dataPolicyOperation> {
  static set: string = 'dataPolicyOperations';
  
  protected resolveEntityKey(entity: Partial<dataPolicyOperation>) {
    return entity.id;
  }
  // Actions
  
  // Functions
  
  // Navigations
  
}
