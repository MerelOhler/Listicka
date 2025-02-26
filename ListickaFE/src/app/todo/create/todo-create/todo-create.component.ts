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
    { value: '1', label: 'Low' },
    { value: '2', label: 'Medium' },
    { value: '3', label: 'High' },
  ];
  colorOptions = [
    { value: '1', label: 'Red' },
    { value: '2', label: 'Green' },
    { value: '3', label: 'Blue' },
  ];
  cadenceOptions = [
    { value: '1', label: 'Every day' },
    { value: '2', label: 'Every week' },
    { value: '3', label: 'Every month on date' },
    { value: '4', label: 'Every end of month' },
    { value: '5', label: 'Every xth weekday of the month' },
    { value: '6', label: 'Every year on date' },
    { value: '7', label: 'Every end of year' },
    { value: '8', label: 'Every xth weekday in the yth month of the year' },
  ];
  
  title = new FormControl('', [Validators.required]);
  importance = new FormControl('', [Validators.required]);
  color = new FormControl('', [Validators.required]);
  description = new FormControl('', []);
  dates = new FormControl('', [Validators.required]);
  recurring = new FormControl('', [Validators.required]);
  cadence = new FormControl('', [Validators.required]);

  constructor() {}

  ngOnInit() {}
}
