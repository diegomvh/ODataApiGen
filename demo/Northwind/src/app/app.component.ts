import { Component, OnInit } from '@angular/core';
import { ProductsService, CategoriesService, Category, Product } from './northwind';
import { expand, map, concatMap } from 'rxjs/operators';
import { empty } from 'rxjs';
import { ODataEntitySetRequest, ODataEntitySet } from 'angular-odata';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Northwind';
  products: Product[];
  categories: Category[];

  constructor(
    private productsService: ProductsService, 
    private categoriesService: CategoriesService
  ) {
  }

  ngOnInit(): void {
    // Fetch using all method from entity service
    this.productsService.all().subscribe(set => console.log(set));
    this.categoriesService.all().subscribe(set => console.log(set));

    // Fetch "all" products using query and skip
    let q = this.productsService.entities();
    let get = (query: ODataEntitySetRequest<Product>, skip = null) => {
      if (skip)
        query.skip(skip);
      return query.get({withCount: true});
    }
    get(q)
    .pipe(
      expand((resp: ODataEntitySet<Product>) => resp.skip ? get(q, resp.skip) : empty()),
      concatMap((resp: ODataEntitySet<Product>) => resp.entities))
    .subscribe(resp => {
      console.log(resp);
    });

    // Fetch by id
    this.productsService.fetch({ProductID: 1}).subscribe(console.log);

    // If the entity has ProductID, the service use "resolveEntityKey" and resolve to PUT method
    this.productsService.save({CategoryID: 7,
        Discontinued: true,
        ProductID: 74,
        ProductName: "Longlife Tofu Tofu",
        QuantityPerUnit: "10 kg pkg.",
        ReorderLevel: 5,
        SupplierID: 4,
        UnitPrice: 10,
        UnitsInStock: 4,
        UnitsOnOrder: 20}).subscribe(console.log);

    // Otherwise resolve to POST
    this.productsService.save(<Product>{CategoryID: 7,
        Discontinued: true,
        ProductName: "Longlife Tofu Tofu",
        QuantityPerUnit: "10 kg pkg.",
        ReorderLevel: 5,
        SupplierID: 4,
        UnitPrice: 10,
        UnitsInStock: 4,
        UnitsOnOrder: 20}).subscribe(console.log);

    // Using query 
    let qp = this.productsService.entity(1);
    qp.post(<Product>{CategoryID: 7,
        Discontinued: true,
        ProductName: "Longlife Tofu Tofu",
        QuantityPerUnit: "10 kg pkg.",
        ReorderLevel: 5,
        SupplierID: 4,
        UnitPrice: 10,
        UnitsInStock: 4,
        UnitsOnOrder: 20
    }).subscribe(console.log);
  }
}
