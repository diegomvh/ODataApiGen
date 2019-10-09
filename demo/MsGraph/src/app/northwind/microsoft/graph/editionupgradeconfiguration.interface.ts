import { windows10EditionType } from './windows10editiontype.enum';
import { editionUpgradeLicenseType } from './editionupgradelicensetype.enum';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface editionUpgradeConfiguration extends deviceConfiguration {
  licenseType: editionUpgradeLicenseType;
  targetEdition: windows10EditionType;
  license: string;
  productKey: string
}
