import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { IItem } from 'src/app/core/state/item';
import { TestStoreQuery, TestStoreService } from 'src/app/core/state/test-store';

@Component({
  selector: 'app-test-async',
  templateUrl: './test-async.component.html',
  styleUrls: ['./test-async.component.css']
})
export class TestAsyncComponent implements OnInit {
  itemsAsyncAndSubscribeTogether: Observable<IItem[]>;
  itemsAsync: Observable<IItem[]>;
  itemsSubscribe: IItem[];
  itemsBehaviorSubject = new BehaviorSubject<IItem[]>([]);
  activeItem$: Observable<IItem>;
  activeItem: IItem;
  baseUrl = 'http://localhost:53683/api/item';

  constructor(
    private httpClient: HttpClient,
    private testStoreService: TestStoreService,
    private testStoreQuery: TestStoreQuery
  ) {}

  ngOnInit(): void {
    this.testStoreQuery.items$.subscribe(state => {
      if (!state.loading && !state.error && Array.isArray(state.ids) && state.ids.length && !state.active) {
        if (!this.testStoreQuery.hasActive(state.ids[0])) {
          this.testStoreQuery.__store__.setActive(state.ids[0]);
          // this.activeItem$ = this.testStoreQuery.selectActive();
          this.activeItem$.subscribe(item => {
            this.activeItem = item;
          });
        }
      }
    });
  }

  onLoadAsyncAndSubscribeTogetherClick(): void {
    this.itemsAsyncAndSubscribeTogether = this.httpClient.get<IItem[]>(this.baseUrl);
    this.itemsAsyncAndSubscribeTogether.subscribe();
  }

  onLoadAsyncClick(): void {
    this.itemsAsync = this.httpClient.get<IItem[]>(this.baseUrl);
  }

  onLoadSubscribeClick(): void {
    this.httpClient.get<IItem[]>(this.baseUrl)
      .subscribe(items => this.itemsSubscribe = items);
  }

  onLoadBehaviorSubjectClick(): void {
    this.httpClient.get<IItem[]>(this.baseUrl)
      .subscribe(items => this.itemsBehaviorSubject.next(items));
  }

  onLoadAndSetActiveClick(): void {
    this.testStoreService.getItems();
  }
}
