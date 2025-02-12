import { Component, OnInit } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-translate',
  templateUrl: './translate.component.html',
  styleUrls: ['./translate.component.css'],
  imports: [TranslateModule],
})
export class TranslateComponent implements OnInit {
  constructor() {}

  ngOnInit() {}
}
