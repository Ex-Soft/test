// https://angular-templates.io/tutorials/about/angular-forms-and-validations

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ErrorStateMatcher } from '@angular/material/core';

export class TestValidationInputErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null): boolean {
    return control && control.invalid;
  }
}

@Component({
  selector: 'app-test-validation',
  templateUrl: './test-validation.component.html',
  styleUrls: ['./test-validation.component.css']
})
export class TestValidationComponent implements OnInit {
  testValidationForm: FormGroup;
  firstName: FormControl;
  lastName: FormControl;
  line1: FormControl;
  line2: FormControl;
  matcher = new TestValidationInputErrorStateMatcher();
  enterAddress = false;
  firstNameMaxLength = 16;
  lastNameMaxLength = 16;
  notWhitespaceErrorMessage = 'The value can\'t contain leading or trailing whitespace';
  valueTooLongErrorMessage = 'The value is too long';

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
  }

  private createForm(): void {
    this.testValidationForm = new FormGroup({
      firstName: this.firstName,
      lastName: this.lastName,
      line1: this.line1,
      line2: this.line2
    });
  }

  public onClose(): void {
    this.dialogRef.close();
  }
}
