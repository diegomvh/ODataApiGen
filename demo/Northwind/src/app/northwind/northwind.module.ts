import { NgModule } from '@angular/core';

import { CategoriesService } from './ODataWebExperimental/Northwind/Model/categories.service';
import { CustomerDemographicsService } from './ODataWebExperimental/Northwind/Model/customerdemographics.service';
import { CustomersService } from './ODataWebExperimental/Northwind/Model/customers.service';
import { EmployeesService } from './ODataWebExperimental/Northwind/Model/employees.service';
import { Order_DetailsService } from './ODataWebExperimental/Northwind/Model/order_details.service';
import { OrdersService } from './ODataWebExperimental/Northwind/Model/orders.service';
import { ProductsService } from './ODataWebExperimental/Northwind/Model/products.service';
import { RegionsService } from './ODataWebExperimental/Northwind/Model/regions.service';
import { ShippersService } from './ODataWebExperimental/Northwind/Model/shippers.service';
import { SuppliersService } from './ODataWebExperimental/Northwind/Model/suppliers.service';
import { TerritoriesService } from './ODataWebExperimental/Northwind/Model/territories.service';
import { Alphabetical_list_of_productsService } from './ODataWebExperimental/Northwind/Model/alphabetical_list_of_products.service';
import { Category_Sales_for_1997Service } from './ODataWebExperimental/Northwind/Model/category_sales_for_1997.service';
import { Current_Product_ListsService } from './ODataWebExperimental/Northwind/Model/current_product_lists.service';
import { Customer_and_Suppliers_by_CitiesService } from './ODataWebExperimental/Northwind/Model/customer_and_suppliers_by_cities.service';
import { InvoicesService } from './ODataWebExperimental/Northwind/Model/invoices.service';
import { Order_Details_ExtendedsService } from './ODataWebExperimental/Northwind/Model/order_details_extendeds.service';
import { Order_SubtotalsService } from './ODataWebExperimental/Northwind/Model/order_subtotals.service';
import { Orders_QriesService } from './ODataWebExperimental/Northwind/Model/orders_qries.service';
import { Product_Sales_for_1997Service } from './ODataWebExperimental/Northwind/Model/product_sales_for_1997.service';
import { Products_Above_Average_PricesService } from './ODataWebExperimental/Northwind/Model/products_above_average_prices.service';
import { Products_by_CategoriesService } from './ODataWebExperimental/Northwind/Model/products_by_categories.service';
import { Sales_by_CategoriesService } from './ODataWebExperimental/Northwind/Model/sales_by_categories.service';
import { Sales_Totals_by_AmountsService } from './ODataWebExperimental/Northwind/Model/sales_totals_by_amounts.service';
import { Summary_of_Sales_by_QuartersService } from './ODataWebExperimental/Northwind/Model/summary_of_sales_by_quarters.service';
import { Summary_of_Sales_by_YearsService } from './ODataWebExperimental/Northwind/Model/summary_of_sales_by_years.service';

@NgModule({
  providers: [
    CategoriesService,
    CustomerDemographicsService,
    CustomersService,
    EmployeesService,
    Order_DetailsService,
    OrdersService,
    ProductsService,
    RegionsService,
    ShippersService,
    SuppliersService,
    TerritoriesService,
    Alphabetical_list_of_productsService,
    Category_Sales_for_1997Service,
    Current_Product_ListsService,
    Customer_and_Suppliers_by_CitiesService,
    InvoicesService,
    Order_Details_ExtendedsService,
    Order_SubtotalsService,
    Orders_QriesService,
    Product_Sales_for_1997Service,
    Products_Above_Average_PricesService,
    Products_by_CategoriesService,
    Sales_by_CategoriesService,
    Sales_Totals_by_AmountsService,
    Summary_of_Sales_by_QuartersService,
    Summary_of_Sales_by_YearsService
  ]
})
export class NorthwindModule { }