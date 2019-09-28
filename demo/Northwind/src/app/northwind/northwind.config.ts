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
  batch: false,
  creation: new Date('2019-09-28T09:05:41.4170701-03:00'),
  version: '4.0',
  enums: {
    
  },
  models: [
    
  ],
  collections: [
    
  ]
}