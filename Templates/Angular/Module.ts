//#region AngularOData Imports
import { 
  NgModule 
} from '@angular/core';//#endregion

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

@NgModule({
  providers: [
//#region ODataApi Providers
    {% for service in Services %}{{service.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}//#endregion
  ]
})
export class {{Name}} { }