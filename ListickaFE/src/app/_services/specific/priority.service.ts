import { inject, Injectable } from '@angular/core';
import { HttpService } from '../general/http.service';

@Injectable({
  providedIn: 'root',
})
export class PriorityService {
  private http = inject(HttpService);

  constructor() {}

  getPriorities(): any {
    return this.http.doGet('priority');
  }
}
