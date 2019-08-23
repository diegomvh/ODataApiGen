import { Component, OnInit } from '@angular/core';
import { ProductsService, ProductCollection, CategoriesService, Category, CategoryCollection } from './northwind';
import { switchMap } from 'rxjs/operators';
import {DomSanitizer} from '@angular/platform-browser';

const b64toBlob = (b64Data, contentType='', sliceSize=512) => {
  const byteCharacters = atob(b64Data);
  const byteArrays = [];

  for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
    const slice = byteCharacters.slice(offset, offset + sliceSize);

    const byteNumbers = new Array(slice.length);
    for (let i = 0; i < slice.length; i++) {
      byteNumbers[i] = slice.charCodeAt(i);
    }

    const byteArray = new Uint8Array(byteNumbers);
    byteArrays.push(byteArray);
  }
  console.log(byteArrays);
    
  const blob = new Blob(byteArrays, {type: contentType});
  return blob;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Northwind';
  products: ProductCollection;
  categories: CategoryCollection;
  category: Category;

  constructor(
    private productsService: ProductsService, 
    private categoriesService: CategoriesService,
    private sanitizer:DomSanitizer
  ) {
    this.products = this.productsService.collection();
    this.categoriesService.collection().fetch().subscribe(categories => this.categories = categories);
    this.categoriesService.model({CategoryID: 2}).fetch().subscribe(c => this.category = c);
  }

  ngOnInit(): void {
    this.fetchProducts();
  }

  async fetchProducts() {
    let products = await this.products.fetch().toPromise();
    for (var p of products)
      console.log(p);
      p.Category = this.category;
      p.save().subscribe(console.log)
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

  imageSrc(b64Data) {
    const contentType = 'image/bmp';

    const blob = b64toBlob(b64Data, contentType);
    return this.sanitizer.bypassSecurityTrustUrl(URL.createObjectURL(blob));
  }
}
