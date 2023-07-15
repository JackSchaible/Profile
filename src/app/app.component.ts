import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = "Jack Schaible's Profile";
  yearsOfExperience = new Date().getFullYear() - 2013;
}
