import { Category } from '../../../NorthwindModel/category.interface';
import { Order_Detail } from '../../../NorthwindModel/order_detail.interface';
import { Product } from '../../../NorthwindModel/product.interface';
import { Supplier } from '../../../NorthwindModel/supplier.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class ProductsService extends ODataEntityService<Product> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Products');
  }
  
  protected resolveEntityKey(entity: Partial<Product>) {
    return entity.ProductID;
  }
  
  public Category(entity: Product, options?): Observable<Category> {
    return this.navigationProperty(entity, 'Category', options)
        .pipe(map(resp => resp.toEntity<Category>()));
  }

  public setCategoryAsCategory(entity: Product, target: ODataQueryBase, options?) {
    return this.createRef(entity, 'Category', target, options);
  }

  public unsetCategoryAsCategory(entity: Product, target: ODataQueryBase, options?) {
    return this.deleteRef(entity, 'Category', target, options);
  }

  public Order_Details(entity: Product, options?): Observable<EntitySet<Order_Detail>> {
    return this.navigationProperty(entity, 'Order_Details', options)
        .pipe(map(resp => resp.toEntitySet<Order_Detail>()));
  }

  public addOrder_DetailToOrder_Details(entity: Product, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Order_Details', target, options);
  }

  public removeOrder_DetailFromOrder_Details(entity: Product, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Order_Details', target, options);
  }

  public Supplier(entity: Product, options?): Observable<Supplier> {
    return this.navigationProperty(entity, 'Supplier', options)
        .pipe(map(resp => resp.toEntity<Supplier>()));
  }

  public setSupplierAsSupplier(entity: Product, target: ODataQueryBase, options?) {
    return this.createRef(entity, 'Supplier', target, options);
  }

  public unsetSupplierAsSupplier(entity: Product, target: ODataQueryBase, options?) {
    return this.deleteRef(entity, 'Supplier', target, options);
  }
}