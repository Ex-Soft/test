import { Component, OnInit } from '@angular/core';
import { TestStoreService, TestStoreQuery } from '../../core/state/test-store';

@Component({
  selector: 'app-test-store',
  templateUrl: './test-store.component.html',
  styleUrls: ['./test-store.component.css']
})
export class TestStoreComponent implements OnInit {
  constructor(
    private testStoreService: TestStoreService,
    private testStoreQuery: TestStoreQuery
  ) {}

  ngOnInit(): void {
    this.testStoreQuery.items$.subscribe(state => {
      if (!state.loading && !state.error && Array.isArray(state.ids) && state.ids.length) {
        const items = this.testStoreQuery.getAll();
        const item = this.testStoreQuery.getEntity(3);
        if (window.console && console.log) {
          console.log('%o %o %o', state.extraData, items, item);
        }
      }
    });
  }

  onTestStoreClick(statusCode?: string): void {
    this.testStoreService.getItems(statusCode);
  }
}
