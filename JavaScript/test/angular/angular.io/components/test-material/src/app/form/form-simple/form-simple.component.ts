import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ErrorStateMatcher } from '@angular/material/core';

export class FormSimpleInputErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null): boolean {
    return control !== null && control.invalid;
  }
}

@Component({
  selector: 'app-form-simple',
  templateUrl: './form-simple.component.html',
  styleUrls: ['./form-simple.component.css']
})
export class FormSimpleComponent implements OnInit {
  formSimple: FormGroup | undefined;
  firstName: FormControl | undefined;
  matcher = new FormSimpleInputErrorStateMatcher();

  constructor(
    private dialogRef: MatDialogRef<FormSimpleComponent>
  ) {  }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.createFormControls();
    this.createForm();
  }

  private createFormControls(): void {
    this.firstName = new FormControl('', [
      Validators.required,
    ]);
  }

  private createForm(): void {
    this.formSimple = new FormGroup({
      firstName: this.firstName as FormControl
    });
  }

  public onClose(): void {
    this.dialogRef.close();
  }
}
