import { Photo } from './photo.interface';
import { PlanItem } from './planitem.interface';
 export interface Trip {
  TripId: number;
  ShareId: string;
  Description: string;
  Name: string;
  Budget: number;
  StartsAt: Date;
  EndsAt: Date;
  Tags: string[];
  Photos?: Photo[];
  PlanItems?: PlanItem[]
}
