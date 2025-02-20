import { Component, inject, OnInit } from '@angular/core';
import {
  IonMenuButton,
  IonToolbar,
  IonTitle,
  IonButtons,
  IonButton,
} from '@ionic/angular/standalone';
import { ThemeService } from '../_services/general/theme.service';
import { AppTranslateService } from '../_services/general/app-translate.service';
import { Router } from '@angular/router';
import { UserService } from '../_services/specific/user.service';
import { LanguageSwitcherComponent } from "./language-switcher/language-switcher.component";

@Component({
  selector: 'l-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
  imports: [IonMenuButton, IonToolbar, IonTitle, IonButtons, IonButton, LanguageSwitcherComponent],
  standalone: true,
})
export class NavBarComponent implements OnInit {
  private userService = inject(UserService);

  title = `Listicka`;
  profile = this.userService.currentUser;
  constructor(
    private themeService: ThemeService,
    private translate: AppTranslateService,
    private router: Router
  ) {}

  ngOnInit() {}

  changeTheme() {
    this.themeService.setTheme({});
  }
  changeLanguage() {
    this.translate.setLanguage('en');
  }

  goToLogin(login: boolean) {
    if (login) this.router.navigate(['/login']);
    else this.router.navigate(['/register']);
  }
}
