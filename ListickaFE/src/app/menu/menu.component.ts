import {
  Component,
  computed,
  OnInit,
  Signal,
  ViewEncapsulation,
} from '@angular/core';
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
import { AppTranslateService } from '../services/general/app-translate.service';

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

  public pages: Signal<any> = computed(() => [
    {
      title: this.translate.home(),
      icon: faHouse,
      url: '/home',
      active: false,
    },
    {
      title: this.translate.profile(),
      icon: faUser,
      url: '/profile',
      active: false,
    },
    {
      title: this.translate.translate(),
      icon: faBullhorn,
      url: '/translate',
      active: false,
    },
    {
      title: 'Logout',
      icon: faArrowRightFromBracket,
      url: '',
      active: false,
    },
  ]);

  profile = {
    name: 'John Doe',
    email: 'asdf',
  };
  title: string = 'Listicka';
  huhu: any;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private translate: AppTranslateService
  ) {}

  ngOnInit() {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe(() => {
        const activeRoute = this.route.root;
        // const indexActivePage = this.pages.findIndex(
        //   (a: any) => a.url === '/' + this.getActiveRoute(activeRoute)
        // );
        // if (indexActivePage >= 0) {
        //   this.pages[indexActivePage].active = true;
        // } else this.pages[0].active = true;
      });
    this.setMenuValues();
  }

  getActiveRoute(route: ActivatedRoute): string {
    while (route.firstChild) {
      route = route.firstChild;
    }
    return route.snapshot.url.join('/');
  }
  onItemSelected(page: any) {
    if (!page.active) {
      // const indexActivePage = this.pages.findIndex((a: any) => a.active);
      // if (indexActivePage >= 0) {
      //   this.pages[indexActivePage].active = false;
      // }
      page.active = true;
    }
    this.router.navigate([page.url]);
  }

  setMenuValues() {
    this.translate.setLanguage('cs');
  }
}
