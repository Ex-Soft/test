import { Component, Inject, Output, EventEmitter } from '@angular/core';

import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-dialog1',
  templateUrl: './dialog1.component.html',
  styleUrls: ['./dialog1.component.css']
})
export class Dialog1Component {
  source: string;

  @Output() closeEvent = new EventEmitter<number>();

  constructor(
    private dialogRef: MatDialogRef<Dialog1Component>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.source = this.data.source;
  }

  public onClose(): void {
    this.dialogRef.close({ data: { source: 'from Dialog1' } });
  }

  public showDialog2(): void {
    this.closeEvent.emit(2);
    this.dialogRef.close({ data: { source: 'from Dialog1' } });
  }
}
