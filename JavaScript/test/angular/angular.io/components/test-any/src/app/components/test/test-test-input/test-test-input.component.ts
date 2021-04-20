import { Component, OnInit } from '@angular/core';
import { SmthType } from './smth.type';

@Component({
  selector: 'app-test-test-input',
  templateUrl: './test-test-input.component.html',
  styleUrls: ['./test-test-input.component.css']
})
export class TestTestInputComponent implements OnInit {
  items: SmthType[];

  constructor() { }

  ngOnInit(): void {
    this.items = [
      { pString1: '1.1', pNumber1: 1, pSubString1: 'sub 1.1', pSubString2: 'sub 1.2' } as SmthType,
      { pString1: '2.1', pString2: '2.2', pNumber1: 2, pNumber2: 2, pSubString1: 'sub 2.1', pSubString3: 'sub 2.3' } as SmthType,
      { pString1: '3.1', pString2: '3.2', pString3: '3.3', pNumber1: 2, pNumber2: 2, pNumber3: 3, pSubString2: 'sub 3.2', pSubString3: 'sub 3.3' } as SmthType,
    ] as SmthType[];
  }
}
