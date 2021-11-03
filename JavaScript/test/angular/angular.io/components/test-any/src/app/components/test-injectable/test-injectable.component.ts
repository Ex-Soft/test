import { Component, OnInit } from '@angular/core';

import { TestInjectableClassWrapper } from './test-injectable';

@Component({
  selector: 'app-test-injectable',
  templateUrl: './test-injectable.component.html',
  styleUrls: ['./test-injectable.component.css']
})
export class TestInjectableComponent implements OnInit {
  pString: string;
  pString1: string;
  pString2: string;
  pArrayOfString: string[];
  pArrayOfString1: string[];
  pArrayOfString2: string[];

  constructor(private testInjectableWrapper: TestInjectableClassWrapper) {}

  ngOnInit(): void {
    this.pString = this.testInjectableWrapper.PString;
    this.pString1 = this.testInjectableWrapper.PString1;
    this.pString2 = this.testInjectableWrapper.PString2;

    this.pArrayOfString = this.testInjectableWrapper.PArrayOfString;
    this.pArrayOfString1 = this.testInjectableWrapper.PArrayOfString1;
    this.pArrayOfString2 = this.testInjectableWrapper.PArrayOfString2;
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
}
