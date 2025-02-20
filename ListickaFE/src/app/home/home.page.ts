import { Component, OnInit } from '@angular/core';
import {
  IonContent,
  IonList,
  IonItem,
  IonLabel,
} from '@ionic/angular/standalone';
import { UserService } from '../_services/specific/user.service';
import { NgIf, CurrencyPipe } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'l-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.css'],
  imports: [IonContent, IonList, IonItem, IonLabel, NgIf, CurrencyPipe, TranslateModule],
})
export class HomePage implements OnInit {
  title = 'Listicka';
  users: any;
  user: any;
  isLoading = true;
  cost = 123.45;

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe({
      next: (response: any) => {
        this.users = response.data;
      },
      error: (error: any) => {
        console.error(error);
      },
      complete: () => {},
    });

    this.userService.getUserById(1).subscribe({
      next: (response: any) => {
        this.user = response.data;
      },
      error: (error: any) => {
        console.error(error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
}
