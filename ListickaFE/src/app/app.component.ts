import { Component, inject, OnInit } from '@angular/core';
import {
  IonApp,
  IonRouterOutlet,
  IonContent,
  IonHeader,
} from '@ionic/angular/standalone';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MenuComponent } from './menu/menu.component';
import { UserService } from './_services/specific/user.service';

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
export class AppComponent implements OnInit {
  private userService = inject(UserService);
  constructor() {}

  ngOnInit() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user = JSON.parse(userString);
    this.userService.currentUser.set(user);
  }
}
