import { Component, OnInit } from '@angular/core';
import {
  IonContent,
  IonList,
  IonItem,
  IonLabel,
  IonHeader,
  IonToolbar,
  IonTitle,
  IonButtons,
  IonMenuButton,
  IonButton,
  IonIcon,
} from '@ionic/angular/standalone';
import { UserService } from '../services/specific/user.service';
import { NgIf } from '@angular/common';
import { ThemeService } from '../services/general/theme.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
  imports: [
    IonContent,
    IonList,
    IonItem,
    IonLabel,
    IonHeader,
    IonToolbar,
    IonTitle,
    IonButtons,
    IonMenuButton,
    IonButton,
    IonIcon,
    NgIf,
  ],
})
export class HomePage implements OnInit {
  title = 'ListickaFE';
  users: any;
  user: any;
  isLoading = true;

  constructor(
    private userService: UserService,
    private themeService: ThemeService
  ) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe({
      next: (response: any) => {
        this.users = response.data;
      },
      error: (error: any) => {
        console.error(error);
      },
      complete: () => {
        console.log('complete');
      },
    });

    this.userService.getUserById(1).subscribe({
      next: (response: any) => {
        this.user = response.data;
      },
      error: (error: any) => {
        console.error(error);
      },
      complete: () => {
        console.log('complete');
        this.isLoading = false;
      },
    });
  }

  changeTheme() {
    this.themeService.setTheme({});
  }
}
