import { Invoice } from './invoice.model';
import { Collection, ODataCollection } from 'angular-odata';

export class InvoiceCollection extends ODataCollection<Invoice> {
  static type = 'NorthwindModel.InvoiceCollection';
  static Model = Invoice;
}