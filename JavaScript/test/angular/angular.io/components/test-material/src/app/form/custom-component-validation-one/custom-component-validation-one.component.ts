// https://medium.com/@tarik.nzl/angular-2-custom-form-control-with-validation-json-input-2b4cf9bc2d73

import { Component, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, NG_VALIDATORS, FormControl, Validator } from '@angular/forms';

@Component({
  selector: 'app-custom-component-validation-one',
  template:
    `
    <textarea
      [value]="jsonString"
      (change)="onChange($event)"
      (keyup)="onChange($event)">
    </textarea>
    `,
  styleUrls: ['./custom-component-validation-one.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CustomComponentValidationOneComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => CustomComponentValidationOneComponent),
      multi: true
    }
  ]
})
export class CustomComponentValidationOneComponent implements ControlValueAccessor, Validator {
  jsonString: string;
  private parseError: boolean;
  private data: any;

  private propagateChange = (_: any) => { };
  private propagateTouched = () => { };

  constructor() { }

  writeValue(obj: any): void {
    if (obj) {
      this.data = obj;
      this.jsonString = JSON.stringify(this.data, undefined, 4);
    }
  }

  registerOnChange(fn: any): void {
    this.propagateChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.propagateTouched = fn;
  }

  onChange(event): void {
    const newValue = event.target.value;
    try {
        this.data = JSON.parse(newValue);
        this.parseError = false;
    } catch (ex) {
        this.parseError = true;
    }

    this.propagateChange(this.data);
    this.propagateTouched();
  }

  public validate(c: FormControl): any {
    return (!this.parseError) ? null : {
        jsonParseError: {
            valid: false,
        },
    };
  }
}
