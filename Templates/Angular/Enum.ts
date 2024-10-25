//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApiGen Type
export const {{TypeName}} = '{{FullName}}';//#endregion
export enum {{Name}} {
  //#region ODataApiGen Members
  {% for member in Members %}{{member}},
  {% endfor %}//#endregion
}
