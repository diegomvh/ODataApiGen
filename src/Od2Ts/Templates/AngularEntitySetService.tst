$imports$

import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { AngularODataServiceBase } from '../AngularOdataServiceBase';

@Injectable()
export class $entitySetName$ extends AngularODataServiceBase<$entityTypeName$> {
    public entitySetUrlSegment = '$entitySetUrl$';
$customActions$$customFunctions$
    constructor(protected http: Http) {
        super();
    }
}
