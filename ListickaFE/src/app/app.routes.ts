import { HomePage } from './home/home.page';
import { ProfileComponent } from './profile/profile.component';
import { TranslateComponent } from './translate/translate.component';
import { LoginComponent } from './login/login.component';
import { TodoListComponent } from './todo/list/todo-list/todo-list.component';
import { TodoCreateComponent } from './todo/create/todo-create/todo-create.component';
import { TodoItemComponent } from './todo/item/todo-item/todo-item.component';

export const routes = [
  { path: '', component: HomePage },
  { path: 'home', component: HomePage },
  { path: 'login', component: LoginComponent, data: { register: false } },
  { path: 'register', component: LoginComponent, data: { register: true } },
  { path: 'profile', component: ProfileComponent },
  { path: 'translate', component: TranslateComponent },
  { path: 'todo', component: TodoListComponent },
  { path: 'todo/create', component: TodoCreateComponent },
  { path: 'todo/:id', component: TodoItemComponent },
];
