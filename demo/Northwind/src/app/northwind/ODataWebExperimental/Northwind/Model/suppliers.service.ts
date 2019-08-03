import { Product } from '../../../NorthwindModel/product.model';
import { Supplier } from '../../../NorthwindModel/supplier.model';
import { ProductCollection } from '../../../NorthwindModel/product.collection';
import { SupplierCollection } from '../../../NorthwindModel/supplier.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class SuppliersService extends ODataModelService {
  static modelType = 'NorthwindModel.Supplier';
  static collectionType = 'NorthwindModel.SupplierCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Suppliers');
  }
  
  model(attrs?: any): Supplier {
    return super.model(attrs) as Supplier;
  }

  collection(attrs?: any): SupplierCollection {
    return super.collection(attrs) as SupplierCollection;
  }
}