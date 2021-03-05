import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-simple',
  templateUrl: './test-simple.component.html',
  styleUrls: ['./test-simple.component.css']
})
export class TestSimpleComponent implements OnInit {
  dateUtc = new Date('2020-02-29T23:59:59.999Z');
  dateWithTimezone = new Date('2020-02-29T23:59:59.999+02:00');
  dateNowLocal = new Date();
  dateNowUtc = new Date(Date.UTC(this.dateNowLocal.getUTCFullYear(), this.dateNowLocal.getUTCMonth(), this.dateNowLocal.getUTCDay(),
      this.dateNowLocal.getUTCHours(), this.dateNowLocal.getUTCMinutes(), this.dateNowLocal.getUTCSeconds(),
      this.dateNowLocal.getUTCMilliseconds()));
  datePstFromLocal = formatDate(this.dateNowLocal, 'full', 'en-US', '-08:00');
  datePstFromUtc = formatDate(this.dateNowUtc, 'full', 'en-US', '-08:00');

  constructor() {}

  ngOnInit(): void {
  }
}
