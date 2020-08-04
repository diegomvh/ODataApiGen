import { EntityConfig } from 'angular-odata';

//#region ODataApi Imports
import { Product } from './product.entity';
//#endregion

export const ProductConfig = {
  name: "Product",
  annotations: [],
  fields: {
    ID: {type: 'Edm.Int32', key: true, ref: 'ID', nullable: false},
    Name: {type: 'Edm.String'},
    Description: {type: 'Edm.String'},
    ReleaseDate: {type: 'Edm.DateTime', nullable: false},
    DiscontinuedDate: {type: 'Edm.DateTime'},
    Rating: {type: 'Edm.Int16', nullable: false},
    Price: {type: 'Edm.Double', nullable: false},
    Categories: {type: '', navigation: true},
    Supplier: {type: '', navigation: true},
    ProductDetail: {type: '', navigation: true}
  }
} as EntityConfig<Product>;