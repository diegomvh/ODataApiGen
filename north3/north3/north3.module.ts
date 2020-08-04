import { NgModule } from '@angular/core';

//#region ODataApi Imports
import { DemoServiceService } from './ODataDemo/demoservice.service';
import { ProductsService } from './ODataDemo/products.service';
import { ProductDetailsService } from './ODataDemo/productdetails.service';
import { CategoriesService } from './ODataDemo/categories.service';
import { SuppliersService } from './ODataDemo/suppliers.service';
import { PersonsService } from './ODataDemo/persons.service';
import { PersonDetailsService } from './ODataDemo/persondetails.service';
import { AdvertisementsService } from './ODataDemo/advertisements.service';
//#endregion

@NgModule({
  providers: [
    DemoServiceService,
    ProductsService,
    ProductDetailsService,
    CategoriesService,
    SuppliersService,
    PersonsService,
    PersonDetailsService,
    AdvertisementsService
  ]
})
export class North3Module { }