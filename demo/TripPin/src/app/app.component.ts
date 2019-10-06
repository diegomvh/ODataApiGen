import { Component } from '@angular/core';
import { Airline, PhotosService } from './trippin';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TripPin';

  constructor(
    private photos: PhotosService
    ) {
      let photoCollection = this.photos.collection();
      photoCollection.fetch().subscribe(console.log);
  }
}
