//#region ODataApi Imports
{% if HasGeoFields %}import { {% for p in GeoProperties %}{{p.Type}}{% unless forloop.last %},{% endunless %}{% endfor %} } from 'geojson';
{% endif %}{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export interface {{Name}}{% if Base != null %} extends {{Base.Name}}{% endif %} {
  //#region ODataApi Properties
  {% for property in Properties %}{{property.Name}}: {{property.Type}};
  {% endfor %}//#endregion
}