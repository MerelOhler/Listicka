import { HomePage } from './home/home.page';
import { ProfileComponent } from './profile/profile.component';
import { TranslateComponent } from './translate/translate.component';
import { LoginComponent } from './login/login.component';

export const routes = [
  { path: 'home', component: HomePage },
  { path: 'login', component: LoginComponent, data: { register: false } },
  { path: 'register', component: LoginComponent, data: { register: true } },
  { path: 'profile', component: ProfileComponent },
  { path: 'translate', component: TranslateComponent },
];
