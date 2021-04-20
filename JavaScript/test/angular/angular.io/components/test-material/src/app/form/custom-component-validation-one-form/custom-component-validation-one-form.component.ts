import { Component } from '@angular/core';
import {FormGroup, FormBuilder} from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-custom-component-validation-one-form',
  templateUrl: './custom-component-validation-one-form.component.html',
  styleUrls: ['./custom-component-validation-one-form.component.css']
})
export class CustomComponentValidationOneFormComponent {
  public result = {};
  public reactiveForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<CustomComponentValidationOneFormComponent>
  ) {
    this.reactiveForm = this.fb.group({
      result: [{test123: 'test456'}]
    });
  }

  public onClose(): void {
    this.dialogRef.close();
  }
}
