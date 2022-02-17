// https://angular-templates.io/tutorials/about/angular-forms-and-validations

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ErrorStateMatcher } from '@angular/material/core';

export class TestValidationInputErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null): boolean {
    return control !== null && control.invalid;
  }
}

@Component({
  selector: 'app-test-validation',
  templateUrl: './test-validation.component.html',
  styleUrls: ['./test-validation.component.css']
})
export class TestValidationComponent implements OnInit {
  testValidationForm!: FormGroup;
  firstName!: FormControl;
  lastName!: FormControl;
  line1!: FormControl;
  line2!: FormControl;
  line3!: FormControl;
  line4!: FormControl;
  matcher = new TestValidationInputErrorStateMatcher();
  enterAddress = false;
  firstNameMaxLength = 16;
  lastNameMaxLength = 16;
  lineMaxLength = 35;
  notWhitespaceErrorMessage = 'The value can\'t contain leading or trailing whitespace';
  valueTooLongErrorMessage = 'The value is too long';
  lineTooLongErrorMessage = `Line cannot exceed ${this.lineMaxLength} characters`;

  constructor(
    private dialogRef: MatDialogRef<TestValidationComponent>
  ) { }

  ngOnInit(): void {
    this.initForm();
  }
  private initForm(): void {
    this.createFormControls();
    this.createForm();
  }

  private createFormControls(): void {
    const notWhiteSpaceRegex = /^([\S].*[\S]|[\S])$/;

    this.firstName = new FormControl('', [
      Validators.required,
      Validators.maxLength(this.firstNameMaxLength),
      Validators.pattern(notWhiteSpaceRegex),
    ]);
    this.lastName = new FormControl('', [
      Validators.required,
      Validators.maxLength(this.lastNameMaxLength),
      Validators.pattern(notWhiteSpaceRegex),
    ]);
    this.line1 = new FormControl('', [
      Validators.required,
    ]);
    this.line2 = new FormControl();
    this.line3 = new FormControl();
    this.line4 = new FormControl('', [
      Validators.maxLength(this.lineMaxLength)
    ]);
  }

  private createForm(): void {
    this.testValidationForm = new FormGroup({
      firstName: this.firstName as FormControl,
      lastName: this.lastName as FormControl,
      line1: this.line1 as FormControl,
      line2: this.line2 as FormControl,
      line3: this.line3 as FormControl,
      line4: this.line4 as FormControl
    });
  }

  public checkBoxAddRemoveValidatorsChange(checked: boolean): void {
    if (this.line3 === undefined) {
      return;
    }

    // https://netbasal.com/three-ways-to-dynamically-alter-your-form-validation-in-angular-e5fd15f1e946
    // https://stackoverflow.com/questions/49075027/angular-dynamically-add-remove-validators
    // https://angular.io/api/forms/AbstractControl#addvalidators
    if (checked) {
      this.line3.setValidators([Validators.maxLength(this.lineMaxLength)]);
      // if (!this.line3.hasValidator(Validators.maxLength(this.lineMaxLength))) {
      //   this.line3.addValidators([Validators.maxLength(this.lineMaxLength)]);
      // }
    } else {
      this.line3.setValidators(null);
      // if (this.line3.hasValidator(Validators.maxLength(this.lineMaxLength))) {
      //   this.line3.removeValidators([Validators.maxLength(this.lineMaxLength)]);
      // }
      // this.line3.clearValidators();
    }
    this.line3.updateValueAndValidity();
  }

  public onClose(): void {
    this.dialogRef.close();
  }
}
