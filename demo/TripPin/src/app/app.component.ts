import { Component } from '@angular/core';
import { AirlinesService, PeopleService, Person, AirportsService } from './trippin';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TripPin';
  constructor(protected airlines: AirlinesService, protected people: PeopleService, protected airports: AirportsService) {
    this.airlines.collection([]).fetch().subscribe(resp => console.log(resp));
    this.people.collection([]).fetch().subscribe(resp => console.log(resp));
    this.airports.collection([]).fetch().subscribe(resp => console.log(resp));
    this.people.model({UserName: "ronaldmundy"})
      .fetch<Person>()
      .subscribe(person => { 
        console.log(person)
        person.LastName = 'van Haaster'; 
        person.save().subscribe();
      });
  }
}
