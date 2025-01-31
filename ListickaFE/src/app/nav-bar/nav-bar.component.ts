import { Component, OnInit } from '@angular/core';
import {
  IonHeader,
  IonMenu,
  IonItem,
  IonAvatar,
  IonLabel,
  IonText,
} from '@ionic/angular/standalone';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
  imports: [IonHeader, IonMenu, IonAvatar, IonLabel, IonText, IonItem],
  standalone: true,
})
export class NavBarComponent implements OnInit {
  profile = { name: 'John Doe', email: 'asdf@asdf.com' };

  constructor() {}

  ngOnInit() {}
}
