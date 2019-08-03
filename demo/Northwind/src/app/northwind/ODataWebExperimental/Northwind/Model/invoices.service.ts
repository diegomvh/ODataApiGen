import { Invoice } from '../../../NorthwindModel/invoice.model';
import { InvoiceCollection } from '../../../NorthwindModel/invoice.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class InvoicesService extends ODataModelService {
  static modelType = 'NorthwindModel.Invoice';
  static collectionType = 'NorthwindModel.InvoiceCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Invoices');
  }
  
  model(attrs?: any): Invoice {
    return super.model(attrs) as Invoice;
  }

  collection(attrs?: any): InvoiceCollection {
    return super.collection(attrs) as InvoiceCollection;
  }
}