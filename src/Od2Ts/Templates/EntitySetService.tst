$imports$
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataService } from "@app/odata";

@Injectable()
export class $entitySetName$ extends ODataEntitySetService<$entityTypeName$> {
  constructor(odata: ODataService, context: ODataContext) {
    super(odata, context, '$entitySetUrl$');
  } 
$customActions$$customFunctions$
}
