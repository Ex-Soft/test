import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-addressy-modal',
  templateUrl: './addressy-modal.component.html',
  styleUrls: ['./addressy-modal.component.css']
})
export class AddressyModalComponent {
  constructor(
    private dialogRef: MatDialogRef<AddressyModalComponent>
  ) { }

  public onClose(): void {
    this.dialogRef.close();
  }

  onAddressSelected(event: any): void {
    console.log(event);
  }

  onEnterAddressManually(): void {
    console.log('onEnterAddressManually');
  }

  onError(event: any): void {
    console.log(event);
  }
}
