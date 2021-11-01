import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-watching',
  templateUrl: './test-watching.component.html',
  styleUrls: ['./test-watching.component.css']
})
export class TestWatchingComponent implements OnInit {
  data = [];

  constructor() {}

  ngOnInit(): void {
  }

  onSetClick(): void {
    this.data = [
      { id: 1, value: '#1' },
      { id: 2, value: '#2' },
      { id: 3, value: '#3' },
    ];
  }
}
