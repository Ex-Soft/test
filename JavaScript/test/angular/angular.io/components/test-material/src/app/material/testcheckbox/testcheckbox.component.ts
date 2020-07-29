import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-testcheckbox',
  templateUrl: './testcheckbox.component.html',
  styleUrls: ['./testcheckbox.component.css']
})
export class TestCheckboxComponent implements OnInit {
  checked: boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
