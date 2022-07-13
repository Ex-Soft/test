import { Injectable } from '@angular/core';
import { tap, finalize } from 'rxjs/operators';
import { createItemsWithEnum } from './item-with-enum.type';
import { ItemsWithEnumStore } from './item-with-enum.store';
import { ItemWithEnumDataService } from './item-with-enum-data.service';

@Injectable({ providedIn: 'root' })
export class ItemWithEnumService {
  constructor(private store: ItemsWithEnumStore, private dataService: ItemWithEnumDataService) {}

  getItemsWithEnum(): void {
    this.store.setLoading(true);
    this.dataService
      .getItemsWithEnum()
      .pipe(
        finalize(() => {
          this.store.setLoading(false);
        }),
        tap(items => {
          this.store.add(createItemsWithEnum(items));
        })
      )
      .subscribe();
  }
}
