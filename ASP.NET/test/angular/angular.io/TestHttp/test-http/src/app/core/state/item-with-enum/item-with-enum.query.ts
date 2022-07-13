import { Injectable } from '@angular/core';
import { QueryEntity } from '@datorama/akita';
import { ItemsWithEnumState, ItemsWithEnumStore } from './item-with-enum.store';
import { IItemWithEnumDto } from './item-with-enum.type';

@Injectable({ providedIn: 'root' })
export class ItemsWithEnumQuery extends QueryEntity<ItemsWithEnumState, IItemWithEnumDto> {
  items$ = this.select(state => state);

  constructor(protected store: ItemsWithEnumStore) {
    super(store);
  }
}
