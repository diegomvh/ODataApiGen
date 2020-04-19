{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}

export class {{Name}} extends {{BaseModel.Name}}<{{Interface.Name}}> {}
