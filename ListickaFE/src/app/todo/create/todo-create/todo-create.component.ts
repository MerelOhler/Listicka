import { Component, inject, OnInit, Signal, signal } from '@angular/core';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import {
  IonList,
  IonItem,
  IonSelect,
  IonInput,
  IonCard,
  IonCardHeader,
  IonCardContent,
  IonCardTitle,
  IonSelectOption,
} from '@ionic/angular/standalone';
import { TranslateModule } from '@ngx-translate/core';
import { PriorityService } from 'src/app/_services/specific/priority.service';

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
    IonSelect,
    IonSelectOption,
  ],
})
export class TodoCreateComponent implements OnInit {
  private priorityService = inject(PriorityService);

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
  priority = new FormControl('', [Validators.required]);
  color = new FormControl('', [Validators.required]);
  dates = new FormControl('', [Validators.required]);
  time = new FormControl('', [Validators.required]);
  recurring = new FormControl('', [Validators.required]);
  cadence = new FormControl('', [Validators.required]);
  allotedTime = new FormControl('', [Validators.required]);
  endDateTime = new FormControl('', []);
  project = new FormControl('', []);

  loading = true;
  priorities = signal<any[]>([]);
  selectedPriority = signal<any>(null);

  constructor() {}

  ngOnInit() {
    this.priorities = this.priorityService.getPriorities().subscribe({
      next: (data: any) => {
        console.log(data.data);
        this.priorities.set(data.data);
        this.loading = false;
        console.log(this.priorities());
      },
    });
  }

  changePriority(event: any) {
    this.selectedPriority.set(event.detail.value);
  }
}
