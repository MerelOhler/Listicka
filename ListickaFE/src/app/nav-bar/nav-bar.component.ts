import { Component, OnInit } from '@angular/core';
import {
  IonMenuButton,
  IonToolbar,
  IonTitle,
  IonButtons,
  IonButton,
} from '@ionic/angular/standalone';
import { ThemeService } from '../services/general/theme.service';
import { AppTranslateService } from '../services/general/app-translate.service';

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

  constructor(private themeService: ThemeService, private translate: AppTranslateService) {}

  ngOnInit() {}

  changeTheme() {
    this.themeService.setTheme({});
  }
  changeLanguage() {
    this.translate.setLanguage('en');
  }

}
