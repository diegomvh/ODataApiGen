import { ODataCollection } from 'angular-odata';

import { Person } from './person.model';

export class PersonCollection extends ODataCollection<Person> implements Iterable<Person> {
  static model = Person;
}
