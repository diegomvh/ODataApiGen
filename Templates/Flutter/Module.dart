//#region ODataApiGen ODataImports
import {
  NgModule
} from '@angular/core';//#endregion

//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

@NgModule({
  providers: [
//#region ODataApiGen Providers
    {% for service in Services %}{{service.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}//#endregion
  ]
})
export class {{Name}} { }