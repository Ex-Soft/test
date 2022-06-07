import { Component, OnInit } from '@angular/core';
import { FormControl, AbstractControl } from '@angular/forms';
import { MatSelectChange } from '@angular/material/select';

@Component({
  selector: 'app-test-select',
  templateUrl: './testselect.component.html',
  styleUrls: ['./testselect.component.css']
})
export class TestSelectComponent implements OnInit {
  options = [
    { value: 1, description: '#1' },
    { value: 2, description: '#2' },
    { value: 3, description: '#3' }
  ];

  selectedValue1!: number;
  // [(ngModel)] will beat [(value)] if both exist
  selectedValue2Value = 1; // 1st
  selectedValue2Model = 2; // 2nd

  select3Control: FormControl;

  constructor() {
    this.select3Control = new FormControl(3, [ this.validateValue ]);
   }

  ngOnInit(): void {
  }
  
  onSelectionChange1(event: Event): void {
    const select = event?.target as HTMLSelectElement;
    console.log("Event %o select.value %i selectedValue2Value %i selectedValue2Model %i", event, select.value, this.selectedValue2Value, this.selectedValue2Model);
  }

  onSelectionChange2(event: MatSelectChange): void {
    console.log("MatSelectChange %o selectedValue2Value %i selectedValue2Model %i", event, this.selectedValue2Value, this.selectedValue2Model);
  }

  onSelectionChange3(event: MatSelectChange): void {
    console.log("MatSelectChange %o selectedValue2Value %i selectedValue2Model %i", event, this.selectedValue2Value, this.selectedValue2Model);
  }

  validateValue = (control: AbstractControl): {[key: string]: any} | null =>  {
    let error = null;

    if (Number.isInteger(control.value) && control.value > 2) {
      error = { valueError: "> 2" };
    }

    return error;
  }
}
