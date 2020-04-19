{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}

export class {{Name}} extends {{BaseCollection.Name}}<{{Model.Interface.Name}}, {{Model.Name}}> {}
