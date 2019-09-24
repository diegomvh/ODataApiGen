

export interface Invoice {
  ShipName: string;
  ShipAddress: string;
  ShipCity: string;
  ShipRegion: string;
  ShipPostalCode: string;
  ShipCountry: string;
  CustomerID: string;
  CustomerName: string;
  Address: string;
  City: string;
  Region: string;
  PostalCode: string;
  Country: string;
  Salesperson: string;
  OrderID: number;
  OrderDate: Date;
  RequiredDate: Date;
  ShippedDate: Date;
  ShipperName: string;
  ProductID: number;
  ProductName: string;
  UnitPrice: number;
  Quantity: number;
  Discount: number;
  ExtendedPrice: number;
  Freight: number;
}