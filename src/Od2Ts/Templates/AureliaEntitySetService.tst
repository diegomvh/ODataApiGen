$imports$

import { AureliaOdataServiceBase } from '../AureliaOdataServiceBase';

export class $Name$ extends AureliaOdataServiceBase<$entityTypeName$> {
$customActions$$customFunctions$
    constructor() {
        super('$entitySetUrl$');
    }
}
