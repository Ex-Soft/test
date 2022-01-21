import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

export class SimpleControlInputErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null): boolean {
    return control !== null && control.invalid;
  }
}

@Component({
  selector: 'app-simple-component',
  templateUrl: './simple-component.component.html',
  styleUrls: ['./simple-component.component.css']
})
export class SimpleComponentComponent implements OnInit {
  lastName: FormControl | undefined;
  matcher = new SimpleControlInputErrorStateMatcher();

  private propagateChange = (_: any) => { };
  private propagateTouched = () => { };

  constructor() { }

  ngOnInit(): void {
    this.createFormControls();
  }

  registerOnChange(fn: any): void {
    this.propagateChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.propagateTouched = fn;
  }

  private createFormControls(): void {
    this.lastName = new FormControl('', [
      Validators.required,
    ]);
  }
}
