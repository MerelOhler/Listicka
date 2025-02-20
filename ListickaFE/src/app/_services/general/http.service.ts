import { Injectable } from '@angular/core';
import { Capacitor, CapacitorHttp } from '@capacitor/core';
import { catchError, from, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  constructor() {}

  isNative = Capacitor.isNativePlatform();
  baseURL = Capacitor.isNativePlatform()
    ? environment.nativeApiURL
    : environment.apiURL;

  // why am I getting a null pointer exception here?

  doGet(route: string): any {
    const options = {
      url: this.baseURL + route,
      method: 'GET',
      headers: {
        'ngrok-skip-browser-warning': 'true',
      },
    };
    return from(CapacitorHttp.get(options));
  }

  doPut(route: string, data: any): any {
    const options = {
      url: this.baseURL + route,
      method: 'PUT',
      headers: {
        'ngrok-skip-browser-warning': 'true',
        'Content-Type': 'application/json',
      },
      data: data,
    };
    return from(CapacitorHttp.put(options));
  }

  doPost(route: string, data: any): any {
    const options = {
      url: this.baseURL + route,
      method: 'POST',
      headers: {
        'ngrok-skip-browser-warning': 'true',
        'Content-Type': 'application/json',
      },
      data: data,
    };
    return from(CapacitorHttp.post(options)).pipe(
      catchError((error) => {
        console.log('huhu');
        if (error.status === 401) {
          // handle unauthorized error
          console.error('Unauthorized access - 401');
        }
        return throwError(() => new Error(error));
      })
    );
  }

  doDelete(route: string): any {
    const options = {
      url: this.baseURL + route,
      method: 'DELETE',
      headers: {
        'ngrok-skip-browser-warning': 'true',
      },
    };
    return from(CapacitorHttp.delete(options));
  }
}
