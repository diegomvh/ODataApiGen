import { EntityConfig } from 'angular-odata';

//#region ODataApi Imports
import { Advertisement } from './advertisement.entity';
//#endregion

export const AdvertisementConfig = {
  name: "Advertisement",
  annotations: [],
  fields: {
    ID: {type: 'Edm.Guid', key: true, ref: 'ID', nullable: false},
    Name: {type: 'Edm.String'},
    AirDate: {type: 'Edm.DateTime', nullable: false},
    FeaturedProduct: {type: '', navigation: true}
  }
} as EntityConfig<Advertisement>;