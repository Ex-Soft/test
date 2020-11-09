import { Component, Inject, Output, EventEmitter } from '@angular/core';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog2',
  templateUrl: './dialog2.component.html',
  styleUrls: ['./dialog2.component.css']
})
export class Dialog2Component {
  source: string;

  @Output() closeEvent = new EventEmitter<number>();

  constructor(
    private dialogRef: MatDialogRef<Dialog2Component>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.source = this.data.source;
  }

  public onClose(): void {
    this.dialogRef.close({ data: { source: 'from Dialog2' } });
  }

  public showDialog1(): void {
    this.closeEvent.emit(1);
    this.dialogRef.close({ data: { source: 'from Dialog2' } });
  }
}
