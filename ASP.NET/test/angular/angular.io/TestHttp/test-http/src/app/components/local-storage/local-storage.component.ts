import { Component, OnInit } from '@angular/core';
import { localStorageKey } from '../../../main';

@Component({
  selector: 'app-local-storage',
  templateUrl: './local-storage.component.html',
  styleUrls: ['./local-storage.component.css']
})
export class LocalStorageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  onSetItemClick(): void {
    if (window.localStorage) {
      const data = JSON.parse(localStorage.getItem(localStorageKey));
      data.js = new Date().toString();
      localStorage.setItem(localStorageKey, JSON.stringify(data));
    }
  }
}
