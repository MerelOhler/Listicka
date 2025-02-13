import { Injectable } from '@angular/core';
import { HttpService } from '../general/http.service';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpService) {}

  getUsers(): any {
    return this.http.doGet('user');
  }

  getUserById(id: number): any {
    return this.http.doGet(`user/${id}`);
  }
}
