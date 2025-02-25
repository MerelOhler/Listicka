import {
  Component,
  computed,
  inject,
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
  faListUl,
} from '@fortawesome/free-solid-svg-icons';
import { FaIconComponent } from '@fortawesome/angular-fontawesome';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgClass } from '@angular/common';
import { NavigationEnd, Router } from '@angular/router';
import { AppTranslateService } from '../_services/general/app-translate.service';
import { RouterHelperService } from '../_services/general/router-helper.service';
import { UserService } from '../_services/specific/user.service';
import { filter, Subscription } from 'rxjs';

@Component({
  selector: 'l-menu',
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
  private router = inject(Router);
  private translate = inject(AppTranslateService);
  private routerHelper = inject(RouterHelperService);
  private userService = inject(UserService);

  faHouse = faHouse;
  faUser = faUser;
  faBullhorn = faBullhorn;
  faArrowRightFromBracket = faArrowRightFromBracket;
  faListUl = faListUl;

  homeActive = signal(false);
  profileActive = signal(false);
  todoActive = signal(false);
  translateActive = signal(false);
  logoutActive = signal(false);

  userProfile = this.userService.currentUser;
  routerSubscription: Subscription;

  public pages: Signal<any> = computed(() => [
    {
      name: 'home',
      title: this.translate.home(),
      icon: faHouse,
      url: '/home',
      active: this.homeActive(),
    },
    {
      name: 'todo',
      title: this.translate.todo(),
      icon: faListUl,
      url: '/todo',
      active: this.todoActive(),
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
      title: this.translate.logout(),
      icon: faArrowRightFromBracket,
      url: '',
      active: false,
    },
  ]);

  constructor() {
    this.routerSubscription = this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event: any) => {
        this.setActive(event.url);
      });
  }

  ngOnInit() {}

  setRouteToHome() {
    this.router.navigate(['/home']);
    this.homeActive.set(true);
  }

  onItemSelected(page: any) {
    if (!page.active) {
      const indexActivePage = this.pages().findIndex((a: any) => a.active);
      if (indexActivePage >= 0) {
        (this as any)[this.pages()[indexActivePage].name + 'Active'].set(false);
      }
      page.active = true;
    }
    this.router.navigate([page.url]);
    if (page.name === 'logout') {
      this.logout();
    }
  }

  setActive(page: string = '') {
    if (page === '') {
      page = this.routerHelper.getActiveRoute();
    }
    const indexActivePage = this.pages().findIndex((a: any) => a.url === page);
    if (indexActivePage >= 0) {
      this.pages().forEach((element: any) => {
        element.active = false;
      });
      (this as any)[this.pages()[indexActivePage].name + 'Active'].set(true);
      this.pages()[indexActivePage].active = true;
    }
  }

  logout() {
    this.userService.logout();
    this.router.navigate(['/home']);
  }

  ngOnDestroy(): void {
    if (this.routerSubscription) {
      this.routerSubscription.unsubscribe();
    }
  }
}
