import { ODataCollection } from 'angular-odata';

import { PlanItem } from './planitem.model';

export class PlanItemCollection extends ODataCollection<PlanItem> {
  static model = PlanItem;
}
