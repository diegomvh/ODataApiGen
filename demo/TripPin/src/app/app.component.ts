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
      peopleCollection.fetch().subscribe(col => {
        for (var person of col) {
          person.Friends.fetch().subscribe(console.log);
          person.Trips.fetch().subscribe(console.log);
          person.Photo.fetch().subscribe(console.log);
        }
      });
  }
}
