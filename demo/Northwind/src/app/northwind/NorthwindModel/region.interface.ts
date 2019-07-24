import { Territory } from './territory.interface';

export interface Region {
  RegionID: number;
  RegionDescription: string;
  Territories?: Territory[];
}