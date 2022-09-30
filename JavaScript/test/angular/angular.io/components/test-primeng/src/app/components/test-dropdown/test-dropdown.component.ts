import { Component } from '@angular/core';

@Component({
  selector: 'app-test-dropdown',
  templateUrl: './test-dropdown.component.html',
  styleUrls: ['./test-dropdown.component.css']
})
export class TestDropdownComponent {
  options1 = [
    { label: "1st", value: 1 },
    { label: "2nd", value: 2 },
    { label: "3rd", value: 3 }
  ];

  options2 = [
    { name: "1st", id: 1 },
    { name: "2nd", id: 2 },
    { name: "3rd", id: 3 }
  ];

  selectedOption1 = 2;
  selectedOption2 = 3;

  onChange(e: Event) {
    console.log(e);
  }
}
