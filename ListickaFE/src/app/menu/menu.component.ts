import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import {
  IonHeader,
  IonMenu,
  IonItem,
  IonAvatar,
  IonLabel,
  IonText,
  IonContent,
  IonMenuToggle,
} from '@ionic/angular/standalone';
import {
  faHouse,
  faBullhorn,
  faArrowRightFromBracket,
  faUser,
} from '@fortawesome/free-solid-svg-icons';
import { FaIconComponent } from '@fortawesome/angular-fontawesome';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgClass } from '@angular/common';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs';

@Component({
  selector: 'menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
  encapsulation: ViewEncapsulation.Emulated,
  imports: [
    IonHeader,
    IonMenu,
    IonAvatar,
    IonLabel,
    IonText,
    IonItem,
    IonContent,
    IonMenuToggle,
    FaIconComponent,
    FontAwesomeModule,
    NgClass,
  ],
  standalone: true,
})
export class MenuComponent implements OnInit {
  faHouse = faHouse;
  faUser = faUser;
  faBullhorn = faBullhorn;
  faArrowRightFromBracket = faArrowRightFromBracket;

  public pages: any = [
    {
      title: 'Home',
      icon: faHouse,
      url: '/home',
      active: false,
    },
    {
      title: 'Profile',
      icon: faUser,
      url: '/profile',
      active: false,
    },
    {
      title: 'Announcement',
      icon: faBullhorn,
      url: '/announcement',
      active: false,
    },
    {
      title: 'Logout',
      icon: faArrowRightFromBracket,
      url: '',
      active: false,
    },
  ];

  profile = {
    name: 'John Doe',
    email: 'asdf',
  };

  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit() {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe(() => {
        const activeRoute = this.route.root;
        const indexActivePage = this.pages.findIndex(
          (a: any) => a.url === '/' + this.getActiveRoute(activeRoute)
        );
        this.pages[indexActivePage].active = true;
      });
  }

  getActiveRoute(route: ActivatedRoute): string {
    while (route.firstChild) {
      route = route.firstChild;
    }
    return route.snapshot.url.join('/');
  }
  onItemSelected(page: any) {
    if (!page.active) {
      const indexActivePage = this.pages.findIndex((a: any) => a.active);
      this.pages[indexActivePage].active = false;
      page.active = true;
    }
    this.router.navigate([page.url]);
  }
}
