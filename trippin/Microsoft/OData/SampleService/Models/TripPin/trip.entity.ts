import { TripSchema } from './trip.schema';
import { Photo } from './photo.entity';
import { PlanItem } from './planitem.entity';

export interface Trip {
  TripId: number;
  ShareId?: string;
  Description?: string;
  Name: string;
  Budget: number;
  StartsAt: Date;
  EndsAt: Date;
  Tags: string[];
  Photos?: Photo[];
  PlanItems?: PlanItem[]
}