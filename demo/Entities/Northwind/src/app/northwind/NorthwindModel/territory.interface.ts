import { Employee } from './employee.interface';
import { Region } from './region.interface';

export interface Territory {
  TerritoryID: string;
  TerritoryDescription: string;
  RegionID: number;
  Region?: Region;
  Employees?: Employee[];
}