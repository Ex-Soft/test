import { Injectable } from '@angular/core';
import { QueryEntity } from '@datorama/akita';
import { ItemsState, ItemsStore } from './item.store';
import { IItem } from './item.type';

@Injectable({ providedIn: 'root' })
export class ItemsQuery extends QueryEntity<ItemsState, IItem> {
  items$ = this.select(state => state);

  constructor(protected store: ItemsStore) {
    super(store);
  }
}
