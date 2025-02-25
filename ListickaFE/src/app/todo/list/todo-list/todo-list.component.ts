import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IonButton } from '@ionic/angular/standalone';

@Component({
  selector: 'l-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css'],
  imports: [IonButton],
})
export class TodoListComponent implements OnInit {
  router = inject(Router);

  constructor() {}

  ngOnInit() {}

  onCreate() {
    this.router.navigate(['/todo/create']);
  }
}
