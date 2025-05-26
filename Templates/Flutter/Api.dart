//#region ODataApiGen ODataImports
import {
  ODataApiConfig,
  EDM_PARSERS
} from 'angular-odata';//#endregion

//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApiGen ApiConfig
export const {{Name}} = {
  serviceRootUrl: '{{Package.ServiceRootUrl}}',
  name: '{{Package.Name}}',
  version: '{{Package.Version}}',
  creation: new Date('{{Package.Creation | date: "o"}}'),
  schemas: [
    {% for schema in Package.Schemas %}{{schema.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ],
  parsers: EDM_PARSERS
} as ODataApiConfig;
//#endregion
