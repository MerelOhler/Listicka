import { inject, Injectable } from '@angular/core';
import { ToastController } from '@ionic/angular/standalone';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  toast = inject(ToastController);

  async presentToast(positive: boolean, message: string) {
    const toast = await this.toast.create({
      message: message,
      duration: 1500,
      position: 'top',
      color: positive ? 'success' : 'danger',
    });

    await toast.present();
  }

}
