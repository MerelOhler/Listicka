import {
  Component,
  computed,
  OnInit,
  signal,
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
import { Router } from '@angular/router';
import { AppTranslateService } from '../_services/general/app-translate.service';
import { RouterHelperService } from '../_services/general/router-helper.service';

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
  homeActive = signal(false);
  profileActive = signal(false);
  translateActive = signal(false);
  logoutActive = signal(false);

  public pages: Signal<any> = computed(() => [
    {
      name: 'home',
      title: this.translate.home(),
      icon: faHouse,
      url: '/home',
      active: this.homeActive(),
    },
    {
      name: 'profile',
      title: this.translate.profile(),
      icon: faUser,
      url: '/profile',
      active: this.profileActive(),
    },
    {
      name: 'translate',
      title: this.translate.translate(),
      icon: faBullhorn,
      url: '/translate',
      active: this.translateActive(),
    },
    {
      name: 'logout',
      title: 'Logout',
      icon: faArrowRightFromBracket,
      url: '',
      active: false,
    },
  ]);

  userProfile = {
    name: 'John Doe',
    email: 'asdf',
  };
  title: string = 'Listicka';
  huhu: any;

  constructor(
    private router: Router,
    private translate: AppTranslateService,
    private routerHelper: RouterHelperService
  ) {}

  ngOnInit() {
    const indexActivePage = this.pages().findIndex(
      (a: any) => a.url === this.routerHelper.getActiveRoute()
    );
    if (indexActivePage >= 0) {
      (this as any)[this.pages()[indexActivePage].name + 'Active'].set(true);
    } else {
      if (this.routerHelper.getActiveRoute() === '') {
        this.setRouteToHome();
      }
    }
    this.setMenuValues();
  }

  setRouteToHome() {
    this.router.navigate(['/home']);
    this.homeActive.set(true);
  }

  onItemSelected(page: any) {
    if (!page.active) {
      const indexActivePage = this.pages().findIndex((a: any) => a.active);
      if (indexActivePage >= 0) {
        this.pages()[indexActivePage].active = false;
      }
      page.active = true;
    }
    this.router.navigate([page.url]);
  }

  setMenuValues() {
    this.translate.setLanguage('cs');
  }
}
