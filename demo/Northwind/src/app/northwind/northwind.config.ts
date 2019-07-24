import { Category } from './NorthwindModel/category.interface';
import { CustomerDemographic } from './NorthwindModel/customerdemographic.interface';
import { Customer } from './NorthwindModel/customer.interface';
import { Employee } from './NorthwindModel/employee.interface';
import { Order_Detail } from './NorthwindModel/order_detail.interface';
import { Order } from './NorthwindModel/order.interface';
import { Product } from './NorthwindModel/product.interface';
import { Region } from './NorthwindModel/region.interface';
import { Shipper } from './NorthwindModel/shipper.interface';
import { Supplier } from './NorthwindModel/supplier.interface';
import { Territory } from './NorthwindModel/territory.interface';
import { Alphabetical_list_of_product } from './NorthwindModel/alphabetical_list_of_product.interface';
import { Category_Sales_for_1997 } from './NorthwindModel/category_sales_for_1997.interface';
import { Current_Product_List } from './NorthwindModel/current_product_list.interface';
import { Customer_and_Suppliers_by_City } from './NorthwindModel/customer_and_suppliers_by_city.interface';
import { Invoice } from './NorthwindModel/invoice.interface';
import { Order_Details_Extended } from './NorthwindModel/order_details_extended.interface';
import { Order_Subtotal } from './NorthwindModel/order_subtotal.interface';
import { Orders_Qry } from './NorthwindModel/orders_qry.interface';
import { Product_Sales_for_1997 } from './NorthwindModel/product_sales_for_1997.interface';
import { Products_Above_Average_Price } from './NorthwindModel/products_above_average_price.interface';
import { Products_by_Category } from './NorthwindModel/products_by_category.interface';
import { Sales_by_Category } from './NorthwindModel/sales_by_category.interface';
import { Sales_Totals_by_Amount } from './NorthwindModel/sales_totals_by_amount.interface';
import { Summary_of_Sales_by_Quarter } from './NorthwindModel/summary_of_sales_by_quarter.interface';
import { Summary_of_Sales_by_Year } from './NorthwindModel/summary_of_sales_by_year.interface';
export const NorthwindConfig = {
  baseUrl: 'https://services.odata.org/V4/Northwind/Northwind.svc/',
  metadataUrl: 'https://services.odata.org/V4/Northwind/Northwind.svc/$metadata',
  withCredentials: true,
  creation: new Date('2019-07-24T00:10:23.0286062-03:00'),
  version: '4.0',
  enums: {
    
  },
  models: {
    'NorthwindModel.Category': Category,
    'NorthwindModel.CustomerDemographic': CustomerDemographic,
    'NorthwindModel.Customer': Customer,
    'NorthwindModel.Employee': Employee,
    'NorthwindModel.Order_Detail': Order_Detail,
    'NorthwindModel.Order': Order,
    'NorthwindModel.Product': Product,
    'NorthwindModel.Region': Region,
    'NorthwindModel.Shipper': Shipper,
    'NorthwindModel.Supplier': Supplier,
    'NorthwindModel.Territory': Territory,
    'NorthwindModel.Alphabetical_list_of_product': Alphabetical_list_of_product,
    'NorthwindModel.Category_Sales_for_1997': Category_Sales_for_1997,
    'NorthwindModel.Current_Product_List': Current_Product_List,
    'NorthwindModel.Customer_and_Suppliers_by_City': Customer_and_Suppliers_by_City,
    'NorthwindModel.Invoice': Invoice,
    'NorthwindModel.Order_Details_Extended': Order_Details_Extended,
    'NorthwindModel.Order_Subtotal': Order_Subtotal,
    'NorthwindModel.Orders_Qry': Orders_Qry,
    'NorthwindModel.Product_Sales_for_1997': Product_Sales_for_1997,
    'NorthwindModel.Products_Above_Average_Price': Products_Above_Average_Price,
    'NorthwindModel.Products_by_Category': Products_by_Category,
    'NorthwindModel.Sales_by_Category': Sales_by_Category,
    'NorthwindModel.Sales_Totals_by_Amount': Sales_Totals_by_Amount,
    'NorthwindModel.Summary_of_Sales_by_Quarter': Summary_of_Sales_by_Quarter,
    'NorthwindModel.Summary_of_Sales_by_Year': Summary_of_Sales_by_Year
  },
  collections: {
    'NorthwindModel.CategoryCollection': CategoryCollection,
    'NorthwindModel.CustomerDemographicCollection': CustomerDemographicCollection,
    'NorthwindModel.CustomerCollection': CustomerCollection,
    'NorthwindModel.EmployeeCollection': EmployeeCollection,
    'NorthwindModel.Order_DetailCollection': Order_DetailCollection,
    'NorthwindModel.OrderCollection': OrderCollection,
    'NorthwindModel.ProductCollection': ProductCollection,
    'NorthwindModel.RegionCollection': RegionCollection,
    'NorthwindModel.ShipperCollection': ShipperCollection,
    'NorthwindModel.SupplierCollection': SupplierCollection,
    'NorthwindModel.TerritoryCollection': TerritoryCollection,
    'NorthwindModel.Alphabetical_list_of_productCollection': Alphabetical_list_of_productCollection,
    'NorthwindModel.Category_Sales_for_1997Collection': Category_Sales_for_1997Collection,
    'NorthwindModel.Current_Product_ListCollection': Current_Product_ListCollection,
    'NorthwindModel.Customer_and_Suppliers_by_CityCollection': Customer_and_Suppliers_by_CityCollection,
    'NorthwindModel.InvoiceCollection': InvoiceCollection,
    'NorthwindModel.Order_Details_ExtendedCollection': Order_Details_ExtendedCollection,
    'NorthwindModel.Order_SubtotalCollection': Order_SubtotalCollection,
    'NorthwindModel.Orders_QryCollection': Orders_QryCollection,
    'NorthwindModel.Product_Sales_for_1997Collection': Product_Sales_for_1997Collection,
    'NorthwindModel.Products_Above_Average_PriceCollection': Products_Above_Average_PriceCollection,
    'NorthwindModel.Products_by_CategoryCollection': Products_by_CategoryCollection,
    'NorthwindModel.Sales_by_CategoryCollection': Sales_by_CategoryCollection,
    'NorthwindModel.Sales_Totals_by_AmountCollection': Sales_Totals_by_AmountCollection,
    'NorthwindModel.Summary_of_Sales_by_QuarterCollection': Summary_of_Sales_by_QuarterCollection,
    'NorthwindModel.Summary_of_Sales_by_YearCollection': Summary_of_Sales_by_YearCollection
  }
}