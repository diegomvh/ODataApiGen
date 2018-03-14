$imports$
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ODataService, ODataResponse } from "../../odata";

@Injectable()
export class $entitySetName$ extends ODataEntitySetService<$entityTypeName$> {
  constructor(odata: ODataService, context: ODataContext) {
    super(odata, context, '$entitySetUrl$');
  } 
$customActions$$customFunctions$
}
