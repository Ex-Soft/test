import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-custom-component-validation-two-form',
  templateUrl: './custom-component-validation-two-form.component.html',
  styleUrls: ['./custom-component-validation-two-form.component.css']
})
export class CustomComponentValidationTwoFormComponent {
  group: FormGroup;

  constructor(
    private dialogRef: MatDialogRef<CustomComponentValidationTwoFormComponent>
  ) {
    this.group = new FormGroup({
      captcha: new FormControl()
    });
  }

  public onClose(): void {
    this.dialogRef.close();
  }
}
