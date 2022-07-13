import { Injectable } from '@angular/core';
import { EntityState, EntityStore, StoreConfig, ActiveState } from '@datorama/akita';
import { IItemWithEnumDto } from './item-with-enum.type';

export interface ItemsWithEnumState extends EntityState<IItemWithEnumDto, number>, ActiveState {}

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'itemswithenum', idKey: 'id', resettable: true })
export class ItemsWithEnumStore extends EntityStore<ItemsWithEnumState, IItemWithEnumDto> {
  constructor() {
    super();

    if (window.console && console.log) {
      console.log('ItemsWithEnumStore.ctor() %o', this.getValue());
    }
  }
}
