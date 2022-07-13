import { Injectable, Inject } from '@angular/core';
import { tap, finalize } from 'rxjs/operators';
import { createItems } from './item.type';
import { ItemsStore } from './item.store';
import { ItemDataService } from './item-data.service';

@Injectable({ providedIn: 'root' })
export class ItemService {
  constructor(private store: ItemsStore, private dataService: ItemDataService) {}

  getItems(): void {
    this.store.setLoading(true);
    this.dataService
      .getItems()
      .pipe(
        finalize(() => {
          this.store.setLoading(false);
        }),
        tap(items => {
          this.store.add(createItems(items));
        })
      )
      .subscribe();
  }
}
