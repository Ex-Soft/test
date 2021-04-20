import { Component, OnInit, OnDestroy, Inject, Input } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-modal-base',
  templateUrl: './modal-base.component.html',
  styleUrls: ['./modal-base.component.css']
})
export class ModalBaseComponent implements OnInit, OnDestroy {
  @Input() title: string;
  @Input() isLoading: boolean;

  constructor(
    private dialogRef: MatDialogRef<ModalBaseComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    if (!!data.title) {
      this.title = data.title;
    }
  }

  ngOnInit(): void { }

  ngOnDestroy(): void { }

  public onClose(): void {
    this.dialogRef.close();
  }
}
