import { booleanColumn } from './booleancolumn.interface';
import { calculatedColumn } from './calculatedcolumn.interface';
import { choiceColumn } from './choicecolumn.interface';
import { currencyColumn } from './currencycolumn.interface';
import { dateTimeColumn } from './datetimecolumn.interface';
import { defaultColumnValue } from './defaultcolumnvalue.interface';
import { lookupColumn } from './lookupcolumn.interface';
import { numberColumn } from './numbercolumn.interface';
import { personOrGroupColumn } from './personorgroupcolumn.interface';
import { textColumn } from './textcolumn.interface';
import { entity } from './entity.interface';

export interface columnDefinition extends entity {
  boolean: booleanColumn;
  calculated: calculatedColumn;
  choice: choiceColumn;
  columnGroup: string;
  currency: currencyColumn;
  dateTime: dateTimeColumn;
  defaultValue: defaultColumnValue;
  description: string;
  displayName: string;
  enforceUniqueValues: boolean;
  hidden: boolean;
  indexed: boolean;
  lookup: lookupColumn;
  name: string;
  number: numberColumn;
  personOrGroup: personOrGroupColumn;
  readOnly: boolean;
  required: boolean;
  text: textColumn
}
