{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}

export class {{Name}}<E extends {{Interface.Name}}> extends {{BaseModel.Name}}<E> {}