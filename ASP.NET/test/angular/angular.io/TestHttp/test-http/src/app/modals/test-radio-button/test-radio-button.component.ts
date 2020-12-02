import { Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { untilDestroyed } from 'ngx-take-until-destroy';

import { IItemDto, ItemsQuery, ItemService } from '../../core/state/item';

@Component({
  selector: 'app-test-radio-button',
  templateUrl: './test-radio-button.component.html',
  styleUrls: ['./test-radio-button.component.css']
})
export class TestRadioButtonComponent implements OnInit, OnDestroy {
  options: IItemDto[] = [];
  selectedOption: number;
  isLoading: boolean;

  constructor(
    private dialogRef: MatDialogRef<TestRadioButtonComponent>,
    private query: ItemsQuery,
    private service: ItemService,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit(): void {
    this.query.items$.pipe(untilDestroyed(this)).subscribe(state => {
      this.isLoading = state.loading;
      const length: number = Array.isArray(state.ids) ? state.ids.length : 0;
      if (length) {
        this.options = this.query.getAll();
        this.selectedOption = state.ids[0];
      } else {
        this.service.getItems();
      }
    });
  }

  ngOnDestroy(): void { }

  public onClose(): void {
    this.dialogRef.close();
  }
}
