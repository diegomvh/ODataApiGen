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
    this.airlines.all().subscribe(resp => console.log(resp));
    this.people.all().subscribe(resp => console.log(resp));
    this.airports.all().subscribe(resp => console.log(resp));
    this.people.model({UserName: "ronaldmundy"}).fetch({parse: true}).subscribe(resp => console.log(resp));
  }
}
