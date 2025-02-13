import { Routes } from '@angular/router';
import { HomePage } from './home/home.page';
import { ProfileComponent } from './profile/profile.component';
import { TranslateComponent } from './translate/translate.component';
import { LoginComponent } from './login/login.component';

export const routes = [
  { path: 'home', component: HomePage },
  { path: 'login', component: LoginComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'translate', component: TranslateComponent },
];
