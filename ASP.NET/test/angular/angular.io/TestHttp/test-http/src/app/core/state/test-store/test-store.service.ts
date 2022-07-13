import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IItem } from '../item/item.type';
import { TestStoreStore } from './test-store.store';

@Injectable({ providedIn: 'root' })
export class TestStoreService {
  baseUrl = 'http://localhost:53683/api/item';

  constructor(
    private http: HttpClient,
    private store: TestStoreStore
  ) {}

  getItems(statusCode?: string): void {
    const value = this.store.getValue();

    // this.store.setLoading(true);
    this.store.update({ loading: true, error: null, extraData: new Date().toLocaleString() });

    let url = `${this.baseUrl}`;
    if (!!statusCode) {
      url += `?statusCode=${statusCode}`;
    }

    this.http
      .get<Array<IItem>>(url)
      .subscribe(
        resp => {
          this.store.set(resp);
        },
        error => {
          // this.store.setError(error.error);
          // this.store.setLoading();
          this.store.update({ loading: false, error, extraData: null });
        }
      );
  }
}
