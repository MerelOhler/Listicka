import { inject, Injectable, signal } from '@angular/core';
import { HttpService } from '../general/http.service';
import { map } from 'rxjs';
import { AppTranslateService } from '../general/app-translate.service';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private http = inject(HttpService);
  currentUser = signal<any | null>(null);

  getUsers(): any {
    return this.http.doGet('user');
  }

  getUserById(id: number): any {
    return this.http.doGet(`user/${id}`);
  }

  login(email: string, password: string) {
    const data = { UserName: email, Password: password };
    return this.http.doPost('account/login', data).pipe(
      map((response: any) => {
        if (response.status !== 200) {
          throw new Error(response.data);
        }
        const user = response.data;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }

  register(
    email: string,
    password: string,
    firstName: string,
    lastName: string,
    language: any
  ) {
    const data = {
      UserName: email,
      Password: password,
      FirstName: firstName,
      LastName: lastName,
      Language: language,
    };
    debugger;
    return this.http.doPost('account/register', data).pipe(
      map((response: any) => {
        if (response.status !== 200) {
          throw new Error(response.data);
        }
        const user = response.data;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })
    );
  }
}
