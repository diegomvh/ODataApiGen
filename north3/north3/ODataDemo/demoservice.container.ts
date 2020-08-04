import { Container } from 'angular-odata';

//#region ODataApi Imports
import { ProductsServiceConfig } from './products.service.config';
import { ProductDetailsServiceConfig } from './productdetails.service.config';
import { CategoriesServiceConfig } from './categories.service.config';
import { SuppliersServiceConfig } from './suppliers.service.config';
import { PersonsServiceConfig } from './persons.service.config';
import { PersonDetailsServiceConfig } from './persondetails.service.config';
import { AdvertisementsServiceConfig } from './advertisements.service.config';
//#endregion

export const DemoServiceContainer = {
  name: "DemoServiceContainer",
  annotations: [],
  services: [
    ProductsServiceConfig,
    ProductDetailsServiceConfig,
    CategoriesServiceConfig,
    SuppliersServiceConfig,
    PersonsServiceConfig,
    PersonDetailsServiceConfig,
    AdvertisementsServiceConfig
  ]
} as Container;