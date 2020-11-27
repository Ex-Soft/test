import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-test-input',
  templateUrl: './testinput.component.html',
  styleUrls: ['./testinput.component.css']
})
export class TestinputComponent {
  numberFormControl = new FormControl('', [
    Validators.required,
    Validators.pattern('^\d{5}$'),
  ]);
}
