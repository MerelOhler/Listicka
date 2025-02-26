import { Component, OnInit } from '@angular/core';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import {
  IonList,
  IonItem,
  IonLabel,
  IonInput,
  IonCard,
  IonCardHeader,
  IonCardContent,
  IonCardTitle,
} from '@ionic/angular/standalone';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-todo-create',
  templateUrl: './todo-create.component.html',
  styleUrls: ['./todo-create.component.css'],
  imports: [
    TranslateModule,
    ReactiveFormsModule,
    IonList,
    IonItem,
    IonInput,
    IonCard,
    IonCardHeader,
    IonCardContent,
    IonCardTitle,
  ],
})
export class TodoCreateComponent implements OnInit {
  importanceOptions = [
    { value: '1', label: 'Can be skipped' },
    { value: '2', label: 'Should happen' },
    {
      value: '3',
      label: 'Should be done before deadline but can go over by some days',
    },
    {
      value: '4',
      label: 'Has to absolutely be done before the next cadence deadline',
    },
    { value: '5', label: 'Has to absolutely be done by deadline' },
  ];

  cadenceOptions = [
    { value: '1', label: 'Every day' },
    { value: '2', label: 'Every weekday' },
    { value: '3', label: 'Every weekend' },
    { value: '4', label: 'Every week' },
    { value: '5', label: 'Every month on date' },
    { value: '6', label: 'Every end of month' },
    { value: '7', label: 'Every nth weekday of the month' },
    { value: '8', label: 'Every year on date' },
    { value: '9', label: 'Every end of year' },
    { value: '10', label: 'Every xth weekday in the yth month of the year' },
  ];

  title = new FormControl('', [Validators.required]);
  importance = new FormControl('', [Validators.required]);
  color = new FormControl('', [Validators.required]);
  description = new FormControl('', []);
  dates = new FormControl('', [Validators.required]);
  recurring = new FormControl('', [Validators.required]);
  cadence = new FormControl('', [Validators.required]);
  timeToFinish = new FormControl('', [Validators.required]);

  constructor() {}

  ngOnInit() {}
}
