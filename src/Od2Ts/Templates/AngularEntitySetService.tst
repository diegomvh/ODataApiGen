$imports$

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataConfiguration, ODataService } from "angular-odata-es5";

@Injectable()
export class $entitySetName$ extends ODataService<$entityTypeName$> {
    constructor(http: HttpClient, config: ODataConfiguration) {
        super('$entitySetUrl$', http, config);
    }
$customActions$$customFunctions$
}
