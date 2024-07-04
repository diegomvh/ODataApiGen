//#region ODataApiGen ODataImports
import {
  Duration
} from 'angular-odata';//#endregion

//#region ODataApiGen Imports
{% if HasGeoFields %}import { {% for p in GeoProperties %}{{p.Type}}{% unless forloop.last %},{% endunless %}{% endfor %} } from 'geojson';
{% endif %}{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApiGen Type
export const {{Name}}Type = '{{FullName}}';//#endregion
export interface {{Name}}{% if Base != null %} extends {{Base.Name}}{% endif %} {
  //#region ODataApiGen Properties
  {% for property in Properties %}{{property.Name}}: {{property.Type}};
  {% endfor %}//#endregion
}