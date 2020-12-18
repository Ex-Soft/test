import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddressyModalComponent } from './addressy/addressy-modal/addressy-modal.component';
import {
  CustomComponentValidationOneFormComponent,
  CustomComponentValidationTwoFormComponent,
  FormSimpleComponent,
  TestValidationComponent
} from './form';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'test-material';

  constructor(
    private dialog: MatDialog
  ) { }

  onAddressyClick(): void {
    const dialogRef = this.dialog.open(AddressyModalComponent, { width: '500px' });
  }

  onCustomComponentValidationOneClick(): void {
    const dialogRef = this.dialog.open(CustomComponentValidationOneFormComponent, { width: '500px' });
  }

  onCustomComponentValidationTwoClick(): void {
    const dialogRef = this.dialog.open(CustomComponentValidationTwoFormComponent, { width: '500px' });
  }

  onFormSimpleClick(): void {
    const dialogRef = this.dialog.open(FormSimpleComponent, { width: '500px' });
  }

  onTestValidationClick(): void {
    const dialogRef = this.dialog.open(TestValidationComponent, { width: '500px' });
  }
}
