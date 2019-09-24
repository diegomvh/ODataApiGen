import { Component } from '@angular/core';
import { PeopleService, PhotosService, AirlinesService, AirportsService } from './trippin';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TripPin';
  data = []

  constructor(
    private photos: PhotosService,
    private people: PeopleService,
    private airlines: AirlinesService,
    private airports: AirportsService
    ) {
    this.photos.all().subscribe(console.log);
    this.people.all().subscribe(console.log);
    this.airlines.all().subscribe(console.log);
    this.airports.all().subscribe(console.log);
  }
}
