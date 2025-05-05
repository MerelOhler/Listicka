import { Component, inject, OnInit } from '@angular/core';
import { AppTranslateService } from 'src/app/_services/general/app-translate.service';
import {
  IonSelect,
  IonSelectOption,
  IonButton,
} from '@ionic/angular/standalone';
import { faGlobe } from '@fortawesome/free-solid-svg-icons';
import { FaIconComponent } from '@fortawesome/angular-fontawesome';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'l-language-switcher',
  templateUrl: './language-switcher.component.html',
  styleUrls: ['./language-switcher.component.css'],
  imports: [
    IonSelect,
    IonSelectOption,
    FaIconComponent,
    FontAwesomeModule,
    TranslateModule,
    IonButton,
  ],
  standalone: true,
})
export class LanguageSwitcherComponent implements OnInit {
  private translateService: AppTranslateService = inject(AppTranslateService);

  languages: any = this.translateService.languages;
  selectedLanguage = this.translateService.language;
  faGlobe = faGlobe;

  constructor() {}

  ngOnInit() {}
  changeLanguage(event: any) {
    this.translateService.setLanguage(event.detail.value);
  }
}
