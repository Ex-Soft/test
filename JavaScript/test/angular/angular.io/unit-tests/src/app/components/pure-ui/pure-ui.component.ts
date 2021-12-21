import { Component, OnInit, Input } from '@angular/core';

import { IData } from '../components.type';

@Component({
  selector: 'app-pure-ui',
  templateUrl: './pure-ui.component.html',
  styleUrls: ['./pure-ui.component.css']
})
export class PureUiComponent implements OnInit {
  @Input() data: IData | null | undefined = undefined;

  constructor() { }

  ngOnInit(): void {
  }

  get pNumberStr(): string {
    return this.data ? `data.pNumber is ${this.data.pNumber ? `${this.data.pNumber < 0 ? "below" : "above or equal to"} zero` : "undefined or null"}` : "Data is undefined or null";
  }
}
