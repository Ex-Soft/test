import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Dialog1Component } from 'src/app/modals/dialog1/dialog1.component';
import { Dialog2Component } from 'src/app/modals/dialog2/dialog2.component';

@Component({
  selector: 'app-dialog-wrapper',
  templateUrl: './dialog-wrapper.component.html',
  styleUrls: ['./dialog-wrapper.component.css']
})
export class DialogWrapperComponent implements OnInit {
  closed: number;

  @Output() closeEvent = new EventEmitter<number>();

  constructor(private dialog: MatDialog) {}

  ngOnInit(): void {}

  public showDialog1(): void {
    const dialogConfig = {
      disableClose: true,
      autoFocus: true,
      data: {
        source: 'to dialog1'
      }
    };

    const dialogRef = this.dialog.open(Dialog1Component, dialogConfig);
    dialogRef.afterClosed().subscribe(data => {
      console.log(data);
    });

    dialogRef.componentInstance.closeEvent.subscribe(dialogNumber => {
      console.log(dialogNumber);
      this.onClose(dialogNumber);
    });
  }

  public showDialog2(): void {
    const dialogRef = this.dialog.open(Dialog2Component, { data: { source: 'to dialog2' }});
    dialogRef.afterClosed().subscribe(data => {
      console.log(data);
    });
    dialogRef.componentInstance.closeEvent.subscribe(dialogNumber => {
      console.log(dialogNumber);
      this.onClose(dialogNumber);
    });
  }

  public onClose(dialogNumber): void {
    this['showDialog' + dialogNumber]();
  }
}
