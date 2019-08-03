import { Component, OnInit } from '@angular/core';
import { ProductsService, ProductCollection } from './northwind';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Northwind';
  products: ProductCollection;

  constructor(private productsService: ProductsService) {
    this.products = this.productsService.collection();
  }

  ngOnInit(): void {
    this.fetchProducts();
  }

  async fetchProducts() {
    let products = await this.products.fetch().toPromise();
    for (var p of products)
      console.log(p);
    products = await products.getNextPage().toPromise();
    for (var p of products)
      console.log(p);
    products = await products.getNextPage().toPromise();
    for (var p of products)
      console.log(p);
    products = await products.getNextPage().toPromise();
    for (var p of products)
      console.log(p);
  }
}
