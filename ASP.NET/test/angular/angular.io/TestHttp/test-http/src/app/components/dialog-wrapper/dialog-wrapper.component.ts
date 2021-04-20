import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TestRadioButtonComponent } from '../../modals/test-radio-button/test-radio-button.component';
import { ModalBaseComponent } from '../../modals/modal-base/modal-base.component';
import { ModalDerivedComponent } from '../../modals/modal-derived/modal-derived.component';

@Component({
  selector: 'app-dialog-wrapper',
  templateUrl: './dialog-wrapper.component.html',
  styleUrls: ['./dialog-wrapper.component.css']
})
export class DialogWrapperComponent implements OnInit {
  constructor(private dialog: MatDialog) { }

  ngOnInit(): void { }

  onTestRadioClick(): void {
    const dialogConfig = {
      width: '400px',
      disableClose: true,
      autoFocus: true,
      data: { }
    };

    const dialogRef = this.dialog.open(TestRadioButtonComponent, dialogConfig);
  }

  onTestModalBaseClick(): void {
    const dialogConfig = {
      width: '400px',
      disableClose: true,
      autoFocus: true,
      data: {
        title: 'Base'
      }
    };

    const dialogRef = this.dialog.open(ModalBaseComponent, dialogConfig);
  }

  onTestModalDerivedClick(): void {
    const dialogConfig = {
      width: '400px',
      disableClose: true,
      autoFocus: true,
      data: {
        title: 'Derived'
      }
    };

    const dialogRef = this.dialog.open(ModalDerivedComponent, dialogConfig);
  }
}
