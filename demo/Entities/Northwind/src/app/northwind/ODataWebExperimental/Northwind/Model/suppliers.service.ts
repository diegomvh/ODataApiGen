import { Product } from '../../../NorthwindModel/product.interface';
import { Supplier } from '../../../NorthwindModel/supplier.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class SuppliersService extends ODataEntityService<Supplier> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Suppliers');
  }
  
  protected resolveEntityKey(entity: Partial<Supplier>) {
    return entity.SupplierID;
  }
  
  public Products(entity: Supplier, options?): Observable<EntitySet<Product>> {
    return this.navigationProperty(entity, 'Products', options)
        .pipe(map(resp => resp.toEntitySet<Product>()));
  }

  public addProductToProducts(entity: Supplier, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Products', target, options);
  }

  public removeProductFromProducts(entity: Supplier, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Products', target, options);
  }
}