import { Order_Detail } from '../../../NorthwindModel/order_detail.interface';
import { Order } from '../../../NorthwindModel/order.interface';
import { Product } from '../../../NorthwindModel/product.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Order_DetailsService extends ODataEntityService<Order_Detail> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Order_Details');
  }
  
  protected resolveEntityKey(entity: Partial<Order_Detail>) {
    return {OrderID: entity.OrderID, ProductID: entity.ProductID};
  }
  
  public Order(entity: Order_Detail, options?): Observable<Order> {
    return this.navigationProperty(entity, 'Order', options)
        .pipe(map(resp => resp.toEntity<Order>()));
  }

  public setOrderAsOrder(entity: Order_Detail, target: ODataQueryBase, options?) {
    return this.createRef(entity, 'Order', target, options);
  }

  public unsetOrderAsOrder(entity: Order_Detail, target: ODataQueryBase, options?) {
    return this.deleteRef(entity, 'Order', target, options);
  }

  public Product(entity: Order_Detail, options?): Observable<Product> {
    return this.navigationProperty(entity, 'Product', options)
        .pipe(map(resp => resp.toEntity<Product>()));
  }

  public setProductAsProduct(entity: Order_Detail, target: ODataQueryBase, options?) {
    return this.createRef(entity, 'Product', target, options);
  }

  public unsetProductAsProduct(entity: Order_Detail, target: ODataQueryBase, options?) {
    return this.deleteRef(entity, 'Product', target, options);
  }
}