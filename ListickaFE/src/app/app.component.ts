import { Component } from '@angular/core';
import { IonApp, IonRouterOutlet } from '@ionic/angular/standalone';
import { NavBarComponent } from './nav-bar/nav-bar.component';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
  imports: [IonApp, IonRouterOutlet, NavBarComponent],
  standalone: true,
})
export class AppComponent {
  constructor() {}
  profile = { name: 'John Doe', email: 'asdf@asdf.com' };
}
