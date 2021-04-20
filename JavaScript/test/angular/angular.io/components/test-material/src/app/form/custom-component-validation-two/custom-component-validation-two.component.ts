// https://netbasal.com/adding-integrated-validation-to-custom-form-controls-in-angular-dc55e49639ae

import { Component, OnInit, ViewChild, forwardRef, ElementRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, NG_VALIDATORS, FormControl, Validator } from '@angular/forms';

@Component({
  selector: 'app-custom-component-validation-two',
  templateUrl: './custom-component-validation-two.component.html',
  styleUrls: ['./custom-component-validation-two.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CustomComponentValidationTwoComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => CustomComponentValidationTwoComponent),
      multi: true
    }
  ]
})
export class CustomComponentValidationTwoComponent implements OnInit, ControlValueAccessor {
  @ViewChild('canvas', { static: true }) canvas: ElementRef<HTMLCanvasElement>;
  answer: number;

  private onChange = (_: any) => { };
  private onTouched = () => { };

  constructor() { }

  ngOnInit(): void {
    this.createCaptcha();
  }

  writeValue(value): void {
    if (window.console && console.log) {
      console.log(value);
    }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  createCaptcha(): void {
    const ctx = this.canvas.nativeElement.getContext('2d');
    const [numOne, numTwo] = [random(), random()];
    this.answer = numOne + numTwo;

    ctx.font = '30px Arial';
    ctx.fillText(`${numOne} + ${numTwo} = `, 10, 35);
  }

  change(value: string): void {
    this.onChange(value);
    this.onTouched();
  }

  validate({ value }: FormControl): any {
    const isNotValid = this.answer !== Number(value);
    return isNotValid && {
      invalid: true
    };
  }
}

function random(): number {
  return Math.floor(Math.random() * 10) + 1;
}
