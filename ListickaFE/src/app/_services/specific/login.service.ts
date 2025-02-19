import { Injectable } from '@angular/core';
import { HttpService } from '../general/http.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private http: HttpService) {}

  login(email: string, password: string) {
    const data = { UserName: email, Password: password };
    return this.http.doPost('account/login', data);
  }

  register(email: string, password: string) {
    const data = { UserName: email, Password: password };
    return this.http.doPost('account/register', data);
  }
}
