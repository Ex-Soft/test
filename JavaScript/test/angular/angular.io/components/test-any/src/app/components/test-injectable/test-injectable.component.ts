import { Component, OnInit/*, Inject*/ } from '@angular/core';

import { TestInjectableClassWrapper, TestInjectableClassWithEvents } from './test-injectable';

@Component({
  selector: 'app-test-injectable',
  templateUrl: './test-injectable.component.html',
  styleUrls: ['./test-injectable.component.css']
})
export class TestInjectableComponent implements OnInit {
  // private testInjectableClassWithEvents: TestInjectableClassWithEvents;

  pString: string;
  pString1: string;
  pString2: string;
  pArrayOfString: string[];
  pArrayOfString1: string[];
  pArrayOfString2: string[];
  date: number;

  constructor(
    private testInjectableWrapper: TestInjectableClassWrapper,
    /*@Inject(TestInjectableClassWithEvents)*/
    private testInjectableClassWithEvents: TestInjectableClassWithEvents
  ) {
    // this.testInjectableClassWithEvents = testInjectableClassWithEvents;
  }

  ngOnInit(): void {
    this.pString = this.testInjectableWrapper.PString;
    this.pString1 = this.testInjectableWrapper.PString1;
    this.pString2 = this.testInjectableWrapper.PString2;

    this.pArrayOfString = this.testInjectableWrapper.PArrayOfString;
    this.pArrayOfString1 = this.testInjectableWrapper.PArrayOfString1;
    this.pArrayOfString2 = this.testInjectableWrapper.PArrayOfString2;

    console.log(this.testInjectableClassWithEvents);
    /* if (this.testInjectableClassWithEvents.on) {
      this.testInjectableClassWithEvents.on('timer', this.onTimer);
    } else if (this.testInjectableClassWithEvents.addListener) {
      this.testInjectableClassWithEvents.addListener('timer', this.onTimer);
    } */
  }

  get PString(): string {
    return this.pString;
  }

  get PString1(): string {
    return this.pString1;
  }

  get PString2(): string {
    return this.pString2;
  }

  get PArrayOfString(): string[] {
    return this.pArrayOfString;
  }

  get PArrayOfString1(): string[] {
    return this.pArrayOfString1;
  }

  get PArrayOfString2(): string[] {
    return this.pArrayOfString2;
  }

  onTimer = (date: Date) => {
    this.date = date.valueOf();
  }
}
