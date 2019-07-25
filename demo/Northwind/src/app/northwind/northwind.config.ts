import { Category } from './NorthwindModel/category.model';
import { CustomerDemographic } from './NorthwindModel/customerdemographic.model';
import { Customer } from './NorthwindModel/customer.model';
import { Employee } from './NorthwindModel/employee.model';
import { Order_Detail } from './NorthwindModel/order_detail.model';
import { Order } from './NorthwindModel/order.model';
import { Product } from './NorthwindModel/product.model';
import { Region } from './NorthwindModel/region.model';
import { Shipper } from './NorthwindModel/shipper.model';
import { Supplier } from './NorthwindModel/supplier.model';
import { Territory } from './NorthwindModel/territory.model';
import { Alphabetical_list_of_product } from './NorthwindModel/alphabetical_list_of_product.model';
import { Category_Sales_for_1997 } from './NorthwindModel/category_sales_for_1997.model';
import { Current_Product_List } from './NorthwindModel/current_product_list.model';
import { Customer_and_Suppliers_by_City } from './NorthwindModel/customer_and_suppliers_by_city.model';
import { Invoice } from './NorthwindModel/invoice.model';
import { Order_Details_Extended } from './NorthwindModel/order_details_extended.model';
import { Order_Subtotal } from './NorthwindModel/order_subtotal.model';
import { Orders_Qry } from './NorthwindModel/orders_qry.model';
import { Product_Sales_for_1997 } from './NorthwindModel/product_sales_for_1997.model';
import { Products_Above_Average_Price } from './NorthwindModel/products_above_average_price.model';
import { Products_by_Category } from './NorthwindModel/products_by_category.model';
import { Sales_by_Category } from './NorthwindModel/sales_by_category.model';
import { Sales_Totals_by_Amount } from './NorthwindModel/sales_totals_by_amount.model';
import { Summary_of_Sales_by_Quarter } from './NorthwindModel/summary_of_sales_by_quarter.model';
import { Summary_of_Sales_by_Year } from './NorthwindModel/summary_of_sales_by_year.model';
import { CategoryCollection } from './NorthwindModel/category.collection';
import { CustomerDemographicCollection } from './NorthwindModel/customerdemographic.collection';
import { CustomerCollection } from './NorthwindModel/customer.collection';
import { EmployeeCollection } from './NorthwindModel/employee.collection';
import { Order_DetailCollection } from './NorthwindModel/order_detail.collection';
import { OrderCollection } from './NorthwindModel/order.collection';
import { ProductCollection } from './NorthwindModel/product.collection';
import { RegionCollection } from './NorthwindModel/region.collection';
import { ShipperCollection } from './NorthwindModel/shipper.collection';
import { SupplierCollection } from './NorthwindModel/supplier.collection';
import { TerritoryCollection } from './NorthwindModel/territory.collection';
import { Alphabetical_list_of_productCollection } from './NorthwindModel/alphabetical_list_of_product.collection';
import { Category_Sales_for_1997Collection } from './NorthwindModel/category_sales_for_1997.collection';
import { Current_Product_ListCollection } from './NorthwindModel/current_product_list.collection';
import { Customer_and_Suppliers_by_CityCollection } from './NorthwindModel/customer_and_suppliers_by_city.collection';
import { InvoiceCollection } from './NorthwindModel/invoice.collection';
import { Order_Details_ExtendedCollection } from './NorthwindModel/order_details_extended.collection';
import { Order_SubtotalCollection } from './NorthwindModel/order_subtotal.collection';
import { Orders_QryCollection } from './NorthwindModel/orders_qry.collection';
import { Product_Sales_for_1997Collection } from './NorthwindModel/product_sales_for_1997.collection';
import { Products_Above_Average_PriceCollection } from './NorthwindModel/products_above_average_price.collection';
import { Products_by_CategoryCollection } from './NorthwindModel/products_by_category.collection';
import { Sales_by_CategoryCollection } from './NorthwindModel/sales_by_category.collection';
import { Sales_Totals_by_AmountCollection } from './NorthwindModel/sales_totals_by_amount.collection';
import { Summary_of_Sales_by_QuarterCollection } from './NorthwindModel/summary_of_sales_by_quarter.collection';
import { Summary_of_Sales_by_YearCollection } from './NorthwindModel/summary_of_sales_by_year.collection';
export const NorthwindConfig = {
  baseUrl: 'https://services.odata.org/V4/Northwind/Northwind.svc/',
  metadataUrl: 'https://services.odata.org/V4/Northwind/Northwind.svc/$metadata',
  withCredentials: true,
  creation: new Date('2019-07-24T18:29:21.3342518-03:00'),
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