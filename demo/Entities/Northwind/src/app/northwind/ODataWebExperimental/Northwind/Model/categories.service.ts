import { Category } from '../../../NorthwindModel/category.interface';
import { Product } from '../../../NorthwindModel/product.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class CategoriesService extends ODataEntityService<Category> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Categories');
  }
  
  protected resolveEntityKey(entity: Partial<Category>) {
    return entity.CategoryID;
  }
  
  public Products(entity: Category, options?): Observable<EntitySet<Product>> {
    return this.navigationProperty(entity, 'Products', options)
        .pipe(map(resp => resp.toEntitySet<Product>()));
  }

  public addProductToProducts(entity: Category, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Products', target, options);
  }

  public removeProductFromProducts(entity: Category, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Products', target, options);
  }
}