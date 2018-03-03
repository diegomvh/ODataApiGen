$imports$

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataConfiguration } from '../angularODataConfiguration';
import { ODataService } from '../angularODataService';

@Injectable()
export class $entitySetName$ extends ODataService<$entityTypeName$> {
    constructor(http: HttpClient, config: ODataConfiguration) {
        super('$entitySetUrl$', http, config);
    }
$customActions$$customFunctions$
}
