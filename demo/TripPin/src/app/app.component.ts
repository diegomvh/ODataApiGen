import { Component } from '@angular/core';
import { ODataModelService } from 'angular-odata';
import { Photo, Airline } from './trippin';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TripPin';

  constructor(
    private models: ODataModelService
    ) {
      let PhotoModel = this.models.model(Airline.type) as typeof Airline;
      let photo = new PhotoModel({AirlineCode: "'AA'"});
      photo.fetch().subscribe(console.log);
  }
}
