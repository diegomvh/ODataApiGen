import { HttpErrorResponse, HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { throwError } from 'rxjs';

import { AppComponent } from './app.component';
import { TripPinModule, TripPinConfig } from './trippin';
import { ODataModule } from 'angular-odata';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ODataModule.forContext(Object.assign({}, TripPinConfig, {
      baseUrl: "https://services.odata.org/TripPinRESTierService/(S(igakoy2xq2x3as3phi2ajn0i))/",
      errorHandler: (error: HttpErrorResponse) => {
        // Custom error processing
        return throwError(error);
      }
    })),
    TripPinModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
