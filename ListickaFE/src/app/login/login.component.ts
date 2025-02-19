import { Component, inject, OnInit } from '@angular/core';
import {
  IonCard,
  IonCardContent,
  IonCardHeader,
  IonCardTitle,
  IonList,
  IonItem,
  IonLabel,
  IonInput,
  IonButton,
  IonInputPasswordToggle,
  ToastController,
} from '@ionic/angular/standalone';
import { TranslateModule } from '@ngx-translate/core';
import { Validators, ReactiveFormsModule, FormControl } from '@angular/forms';
import { NgClass, NgIf } from '@angular/common';
import { LoginService } from '../_services/specific/login.service';
import { Router } from '@angular/router';
import { AppTranslateService } from '../_services/general/app-translate.service';

export const StrongPasswordRegx: RegExp =
  /^(?=[^A-Z]*[A-Z])(?=[^a-z]*[a-z])(?=\D*\d).{8,}$/;
export const emailRegex: RegExp =
  /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [
    IonCard,
    IonCardContent,
    IonCardHeader,
    IonCardTitle,
    TranslateModule,
    IonList,
    IonItem,
    IonLabel,
    IonInput,
    ReactiveFormsModule,
    IonButton,
    NgClass,
    NgIf,
    IonInputPasswordToggle,
  ],
})
export class LoginComponent implements OnInit {
  loading = true;
  register: boolean = true;

  email = new FormControl('', [
    Validators.required,
    Validators.email,
    Validators.pattern(emailRegex),
  ]);
  password = new FormControl('', [
    Validators.required,
    Validators.minLength(6),
    Validators.pattern(StrongPasswordRegx),
  ]);
  confirmPassword = new FormControl('', [
    Validators.required,
    Validators.minLength(6),
  ]);

  loginService = inject(LoginService);
  appTranslateService = inject(AppTranslateService);
  router = inject(Router);
  toast = inject(ToastController);

  ngOnInit() {
    this.confirmPassword.setValidators(this.passwordConfirming);
    this.loading = false;
  }

  loginUser() {
    const email = this.email.getRawValue();
    const password = this.password.getRawValue();
    if (email && password) {
      this.loginService.login(email, password).subscribe({
        next: (response: any) => {
          console.log(response);
          if (response.status === 200) {
            console.log('login successful');
            this.router.navigate(['home']);
          } else {
            this.handleError(response);
          }
        },
        error: (error: any) => {
          this.handleError(error);
        },
      });
    }
  }

  registerUser() {
    if (this.validate()) {
      const email = this.email.getRawValue();
      const password = this.password.getRawValue();
      if (email && password) {
        this.loginService.register(email, password).subscribe({
          next: (response: any) => {
            console.log(response);
            if (response.status === 200) {
              console.log('registration successful');
              this.appTranslateService
                .getTranslation('Registration successful')
                .subscribe((response) => {
                  this.presentToast(true, response);
                });
              this.router.navigate(['home']);
            } else {
              this.handleError(response);
            }
          },
          error: (error: any) => {
            this.handleError(error);
          },
        });
      }
    }
  }

  validate() {
    if (this.password.getRawValue() !== this.confirmPassword.getRawValue()) {
      console.log('passwords do not match');
      this.confirmPassword.setErrors({ notSame: true });
      return false;
    }
    return true;
  }

  handleError(error: any) {
    if (error.data === '') {
      this.appTranslateService
        .getTranslation('Something went wrong, please try again')
        .subscribe((response) => {
          this.presentToast(false, response);
        });
    } else {
      console.log(error.data);
      this.appTranslateService
        .getTranslation(error.data)
        .subscribe((response) => {
          this.presentToast(false, response);
        });
    }
  }

  async presentToast(positive: boolean, message: string) {
    const toast = await this.toast.create({
      message: message,
      duration: 1500,
      position: 'top',
      color: positive ? 'success' : 'danger',
    });

    await toast.present();
  }

  passwordConfirming = () => {
    if (this.confirmPassword?.getRawValue() === '') return { invalid: true };
    return this.password?.getRawValue() === this.confirmPassword?.getRawValue()
      ? null
      : { notSame: true };
  };
}
