import { Injectable } from '@angular/core';
import { CapacitorHttp } from '@capacitor/core';
import { from } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  constructor() {}

  // why am I getting a null pointer exception here?

  doGet(url: string): any {
    console.log('doGet');
    const options = {
      url: url,
      method: 'GET',
    };
    return from(CapacitorHttp.get(options));
  }
}
