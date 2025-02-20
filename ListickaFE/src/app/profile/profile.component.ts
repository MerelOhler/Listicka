import { Component, OnInit } from '@angular/core';
import { IonContent } from '@ionic/angular/standalone';

@Component({
  selector: 'l-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  imports: [IonContent],
})
export class ProfileComponent implements OnInit {
  constructor() {}

  ngOnInit() {}
}
