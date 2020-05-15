//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export interface {{Name}}{% if Base != null %} extends {{Base.Name}}{% endif %} {
  //#region ODataApi Properties
  {% for property in Properties %}{{property.Name}}: {{property.Type}};
  {% endfor %}//#endregion
}