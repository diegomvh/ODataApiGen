import { Component } from '@angular/core';
import { Airline, PhotosService, AirportsService, PeopleService } from './trippin';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TripPin';

  constructor(
    private people: PeopleService
    ) {
      let peopleCollection = this.people.collection();
      peopleCollection.fetch().subscribe(console.log);
  }
}
