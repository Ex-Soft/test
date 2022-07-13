import { Injectable } from '@angular/core';
import { QueryEntity } from '@datorama/akita';
import { TestStoreState, TestStoreStore } from './test-store.store';
import { IItem } from '../item/item.type';

@Injectable({ providedIn: 'root' })
export class TestStoreQuery extends QueryEntity<TestStoreState, IItem> {
  items$ = this.select(state => state);

  constructor(protected store: TestStoreStore) {
    super(store);
  }
}
