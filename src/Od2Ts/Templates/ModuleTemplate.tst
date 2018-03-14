import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

$imports$
@NgModule({
  providers: [
    $moduleProviders$,
    { provide: ODataContext, useClass: ODataContext }
  ]
})
export class $moduleName$Module { }
