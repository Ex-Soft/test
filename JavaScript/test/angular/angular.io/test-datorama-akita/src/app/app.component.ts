// https://datorama.github.io/akita/docs/store
// https://datorama.github.io/akita/docs/query

import { Component, OnInit } from '@angular/core';

import {
  ISimpleObject,
  SimpleObjectStore,
  SimpleObjectQuery
 } from './state';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(
    private simpleObjectStore: SimpleObjectStore,
    private simpleObjectQuery: SimpleObjectQuery
  ) {}

  ngOnInit(): void {
  }

  simpleObjectSetClick() {
    const data = [
      { id: 1, name: 'Item# 1' },
      { id: 1, name: 'Item# 2' },
      { id: 1, name: 'Item# 3' }
    ];

    this.simpleObjectStore.set(data);
  }
}
