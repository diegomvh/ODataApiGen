import { Schema } from 'angular-odata';

//#region ODataApi Imports
import { AddressConfig } from './address.entity.config';
import { ProductConfig } from './product.entity.config';
import { FeaturedProductConfig } from './featuredproduct.entity.config';
import { ProductDetailConfig } from './productdetail.entity.config';
import { CategoryConfig } from './category.entity.config';
import { SupplierConfig } from './supplier.entity.config';
import { PersonConfig } from './person.entity.config';
import { CustomerConfig } from './customer.entity.config';
import { EmployeeConfig } from './employee.entity.config';
import { PersonDetailConfig } from './persondetail.entity.config';
import { AdvertisementConfig } from './advertisement.entity.config';
import { DemoServiceContainer } from './demoservice.container';
//#endregion

export const ODataDemoSchema = {
  namespace: "ODataDemo",
  enums: [],
  entities: [AddressConfig,
    ProductConfig,
    FeaturedProductConfig,
    ProductDetailConfig,
    CategoryConfig,
    SupplierConfig,
    PersonConfig,
    CustomerConfig,
    EmployeeConfig,
    PersonDetailConfig,
    AdvertisementConfig],
  callables: [],
  containers: [DemoServiceContainer]
} as Schema;