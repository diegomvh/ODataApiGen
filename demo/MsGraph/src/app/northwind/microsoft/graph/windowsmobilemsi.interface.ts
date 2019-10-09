import { mobileLobApp } from './mobilelobapp.interface';

export interface windowsMobileMSI extends mobileLobApp {
  commandLine: string;
  productCode: string;
  productVersion: string;
  ignoreVersionDetection: boolean
}
