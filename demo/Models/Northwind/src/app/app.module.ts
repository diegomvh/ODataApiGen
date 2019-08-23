import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NorthwindModule, NorthwindConfig } from './northwind';
import { HttpClientModule, HttpErrorResponse } from '@angular/common/http';
import { ODataModule } from 'angular-odata';
import { throwError } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ODataModule.forContext(Object.assign({}, NorthwindConfig, {
      baseUrl: "https://services.odata.org/V4/Northwind/Northwind.svc/",
      withCredentials: false,
      errorHandler: (error: HttpErrorResponse) => {
        // Custom error processing
        return throwError(error);
      }
    })),
    NorthwindModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
