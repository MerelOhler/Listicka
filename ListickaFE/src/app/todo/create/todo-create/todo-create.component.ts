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
    { value: '1', label: 'Daily' },
    { value: '2', label: 'Daily only on weekdays' },
    { value: '3', label: 'Daily only on weekend days' },
    { value: '4', label: 'Weekly' },
    { value: '5', label: 'Monthly on a specific date' },
    { value: '6', label: 'At the end of every month' },
    { value: '7', label: 'Monthly on the 3rd Monday' },
    { value: '8', label: 'Yearly on a specific date' },
    { value: '9', label: 'At the end of every year' },
    { value: '10', label: 'Yearly on the 3rd Monday in February' },
  ];

  title = new FormControl('', [Validators.required]);
  description = new FormControl('', []);
  importance = new FormControl('', [Validators.required]);
  color = new FormControl('', [Validators.required]);
  dates = new FormControl('', [Validators.required]);
  time = new FormControl('', [Validators.required]);
  recurring = new FormControl('', [Validators.required]);
  cadence = new FormControl('', [Validators.required]);
  allotedTime = new FormControl('', [Validators.required]);
  endDateTime = new FormControl('', []);
  project = new FormControl('', []);

  constructor() {}

  ngOnInit() {}
}
