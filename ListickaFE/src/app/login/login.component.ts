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
  IonSpinner,
} from '@ionic/angular/standalone';
import { TranslateModule } from '@ngx-translate/core';
import { Validators, ReactiveFormsModule, FormControl } from '@angular/forms';
import { NgClass, NgIf } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { AppTranslateService } from '../_services/general/app-translate.service';
import { UserService } from '../_services/specific/user.service';
import { ToastService } from '../_services/general/toast.service';

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
    IonSpinner,
  ],
})
export class LoginComponent implements OnInit {
  private userService = inject(UserService);
  private appTranslateService = inject(AppTranslateService);
  private router = inject(Router);
  private toast = inject(ToastService);
  private route = inject(ActivatedRoute);

  loading = true;
  register: boolean = true;

  name = new FormControl('', [Validators.required]);
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

  ngOnInit() {
    if (this.userService.currentUser()) {
      this.router.navigate(['home']);
    }
    this.confirmPassword.setValidators(this.passwordConfirming);
    this.route.data.subscribe((data) => {
      this.register = data['register'];
    });
    this.loading = false;
  }

  loginUser() {
    const email = this.email.getRawValue();
    const password = this.password.getRawValue();
    if (email && password) {
      this.loading = true;
      this.userService.login(email, password).subscribe({
        next: (response: any) => {
          this.loading = false;
          this.router.navigate(['home']);
        },
        error: (error: any) => {
          this.handleError(error);
        },
      });
    } else if (!email) {
      this.email.setErrors({ required: true });
    } else if (!password) {
      this.password.setErrors({ required: true });
    }
  }

  registerUser() {
    if (this.validate()) {
      const email = this.email.getRawValue();
      const password = this.password.getRawValue();
      const name = this.name.getRawValue();
      if (email && password && name) {
        this.loading = true;
        this.userService.register(email, password, name).subscribe({
          next: () => {
            this.loading = false;
            this.router.navigate(['home']);
          },
          error: (error: any) => {
            this.handleError(error);
          },
        });
      } else if (!email) {
        this.email.setErrors({ required: true });
      } else if (!password) {
        this.password.setErrors({ required: true });
      } else if (!name) {
        this.name.setErrors({ required: true });
      }
    }
  }

  validate() {
    if (this.password.getRawValue() !== this.confirmPassword.getRawValue()) {
      this.confirmPassword.setErrors({ notSame: true });
      return false;
    }
    return true;
  }

  handleError(error: any) {
    console.log(error);
    if (error.message === 'Invalid username or password') {
      this.appTranslateService
        .getTranslation('Invalid username or password')
        .subscribe((response) => {
          this.toast.presentToast(false, response);
          this.loading = false;
        });
    } else {
      this.appTranslateService
        .getTranslation('Something went wrong, please try again')
        .subscribe((response) => {
          this.toast.presentToast(false, response);
          this.loading = false;
        });
    }
  }

  passwordConfirming = () => {
    if (this.confirmPassword?.getRawValue() === '') return { invalid: true };
    return this.password?.getRawValue() === this.confirmPassword?.getRawValue()
      ? null
      : { notSame: true };
  };
}
