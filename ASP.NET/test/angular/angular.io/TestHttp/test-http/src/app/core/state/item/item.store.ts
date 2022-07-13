import { Injectable } from '@angular/core';
import { EntityState, EntityStore, StoreConfig, ActiveState } from '@datorama/akita';
import { IItem } from './item.type';

export interface ItemsState extends EntityState<IItem, number>, ActiveState {}

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'items', idKey: 'id', resettable: true })
export class ItemsStore extends EntityStore<ItemsState, IItem> {
  constructor() {
    super();

    if (window.console && console.log) {
      console.log('ItemStore.ctor() %o', this.getValue());
    }
  }

  akitaPreAddEntity(item: IItem): IItem {
    return item;
  }
}
