import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import {
  IonHeader,
  IonToolbar,
  IonTitle,
  IonContent,
} from '@ionic/angular/standalone';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
  imports: [IonHeader, IonToolbar, IonTitle, IonContent],
})
export class HomePage implements OnInit {
  http = inject(HttpClient);
  title = 'ListickaFE';
  users: any;
  status = 'offline';
  status2 = 'status2';
  url = 'https://localhost:5001/api/user';
  url2 = 'https://store.steampowered.com/api/featuredcategories';

  constructor(private httpService: HttpService) {}

  ngOnInit(): void {
    console.log('ngOnInit');
    this.httpService.doGet(this.url).subscribe({
      next: (response: any) => {
        this.status2 = 'online service';
        this.users = response;
        this.status = 'online service';
      },
      error: (error: any) => {
        this.status2 = 'theres an error service';
        console.error(error + ' service');
        this.status = error.message + ' service';
      },
      complete: () => {
        console.log('complete');
        this.status = 'complete';
      },
    });

    // this.http.get('https://localhost:5001/api/user').subscribe({
    //   next: (response: any) => {
    //     this.users = response;
    //     this.status = 'online';
    //   },
    //   error: (error: any) => {
    //     console.error(error);
    //     this.status = error.message;
    //   },
    //   complete: () => {
    //     console.log('complete');
    //     this.status = 'complete';
    //   },
    // });
  }
}
