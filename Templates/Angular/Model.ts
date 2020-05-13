{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}

export class {{Name}}<E extends {{Entity.Name}}> extends {{BaseModel.Name}}<E> {}