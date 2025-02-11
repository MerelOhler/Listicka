import { Component } from '@angular/core';
import {
  IonApp,
  IonRouterOutlet,
  IonContent,
  IonHeader,
} from '@ionic/angular/standalone';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MenuComponent } from './menu/menu.component';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.css'],
  imports: [
    IonApp,
    IonRouterOutlet,
    NavBarComponent,
    MenuComponent,
    IonContent,
    IonHeader,
  ],
  standalone: true,
})
export class AppComponent {
  constructor() {}
  profile = { name: 'John Doe', email: 'asdf@asdf.com' };
}
