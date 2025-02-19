import { Component, OnInit } from '@angular/core';
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

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
  imports: [IonMenuButton, IonToolbar, IonTitle, IonButtons, IonButton],
  standalone: true,
})
export class NavBarComponent implements OnInit {
  title = `Listicka`;
  profile = { name: 'John Doe', email: 'asdf@asdf.com' };

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

  goToLogin() {
    this.router.navigate(['/login']);
  }
}
