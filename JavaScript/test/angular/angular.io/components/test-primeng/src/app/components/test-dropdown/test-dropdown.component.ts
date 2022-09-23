import { Component } from '@angular/core';

@Component({
  selector: 'app-test-dropdown',
  templateUrl: './test-dropdown.component.html',
  styleUrls: ['./test-dropdown.component.css']
})
export class TestDropdownComponent {
  options = [
    { label: "1st", value: 1 },
    { label: "2nd", value: 2 },
    { label: "3rd", value: 3 }
  ];

  selectedOption = 2;

  onChange(e: Event) {
    console.log(e, this.selectedOption);
  }
}
