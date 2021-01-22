import { Component, OnInit } from '@angular/core';
import { createVictim } from 'src/app/models/IVictim.mock';

@Component({
  selector: 'app-test-facker',
  templateUrl: './test-facker.component.html',
  styleUrls: ['./test-facker.component.css']
})
export class TestFackerComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
  }

  onClickCheck(): void {
    const victim = createVictim({ id: 123, p1: '1st', p2: '2nd', p3: '3rd', subGroup1: { id: 456, p1: '1st' } });
    if (window.console && console.log) {
      console.log(victim);
    }
  }
}
