import { Routes } from '@angular/router';
import { HomePage } from './home/home.page';
import { ProfileComponent } from './profile/profile.component';
import { TranslateComponent } from './translate/translate.component';

export const routes = [
  { path: 'home', component: HomePage },
  { path: 'profile', component: ProfileComponent },
  { path: 'translate', component: TranslateComponent },
];
