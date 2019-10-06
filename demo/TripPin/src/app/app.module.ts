import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// Material
import {MatTableModule} from '@angular/material/table';

// Odata
import { ODataModule } from 'angular-odata';

// Generated API
import { TripPinConfig, TripPinModule } from './trippin';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    MatTableModule,
    ODataModule.forConfig(TripPinConfig),
    TripPinModule,
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
