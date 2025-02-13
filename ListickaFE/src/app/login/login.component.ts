import { Component, OnInit } from '@angular/core';
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
} from '@ionic/angular/standalone';
import { TranslateModule } from '@ngx-translate/core';
import { Validators, ReactiveFormsModule, FormControl } from '@angular/forms';
import { NgClass, NgIf } from '@angular/common';
import { LoginService } from '../services/specific/login.service';
import { Router } from '@angular/router';

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

  constructor(private loginService: LoginService, private router: Router) {}

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
    console.error(error);
    //TODO: handle error
  }

  passwordConfirming = () => {
    if (this.confirmPassword?.getRawValue() === '') return { invalid: true };
    return this.password?.getRawValue() === this.confirmPassword?.getRawValue()
      ? null
      : { notSame: true };
  };
}
