import { inject, Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root',
})
export class AppLanguagesService {
  private http = inject(HttpService);

  constructor() {}

  getLanguages(): any {
    return this.http.doGet(`language`);
  }
}
