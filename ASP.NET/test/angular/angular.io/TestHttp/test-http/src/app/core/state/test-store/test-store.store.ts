import { Injectable } from '@angular/core';
import { EntityState, EntityStore, StoreConfig, ActiveState } from '@datorama/akita';
import { IItem } from '../item/item.type';

export interface TestStoreState extends EntityState<IItem, number>, ActiveState {
  extraData: any;
}

const initialState: TestStoreState = {
  active: null,
  loading: false,
  extraData: null
};

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'test-store', idKey: 'id', resettable: true })
export class TestStoreStore extends EntityStore<TestStoreState, IItem> {
  constructor() {
    super(initialState);

    if (window.console && console.log) {
      console.log('TestStoreStore.ctor() %o', this.getValue());
    }
  }
}
