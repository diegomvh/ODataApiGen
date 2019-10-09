import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { domainDnsRecord } from './domaindnsrecord.interface';


@Injectable()
export class DomainDnsRecordsService extends ODataEntityService<domainDnsRecord> {
  static set: string = 'domainDnsRecords';
  
  protected resolveEntityKey(entity: Partial<domainDnsRecord>) {
    return entity.id;
  }
  // Actions
  
  // Functions
  
  // Navigations
  
}
