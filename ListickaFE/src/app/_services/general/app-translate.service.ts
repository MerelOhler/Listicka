import { Injectable, signal } from '@angular/core';
import { TranslateService, TranslateModule } from '@ngx-translate/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AppTranslateService {
  home = signal('Home');
  profile = signal('Profile');
  translate = signal('Translate');
  logout = signal('Logout');
  login = signal('Login');
  register = signal('Register');
  settings = signal('Settings');
  language = signal('en');

  constructor(private translateService: TranslateService) {
    this.translateService.setDefaultLang('en');
    this.translateService.use('en');
  }

  public getTranslation(key: string): Observable<string> {
    return this.translateService.get(key);
  }

  public getTranslations(translations: any): Observable<any> {
    return this.translateService.get(translations);
  }

  public setLanguage(lang: string): void {
    this.language.set(lang);
    this.translateService.use(lang).subscribe(() => {
      this.setMenuValues();
      this.setNavValues();
    });
  }

  setMenuValues() {
    this.getTranslations([
      'home',
      'profile',
      'translate',
      'logout',
      'login',
      'register',
      'settings',
    ]).subscribe((translations) => {
      this.home.set(translations.home);
      this.profile.set(translations.profile);
      this.translate.set(translations.translate);
      this.logout.set(translations.logout);
      this.login.set(translations.login);
      this.register.set(translations.register);
      this.settings.set(translations.settings);
    });
  }
  setNavValues() {}
}
