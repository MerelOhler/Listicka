import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class RouterHelperService {
  constructor() {}
  getActiveRoute() {
    return window.location.pathname;
  }
}
