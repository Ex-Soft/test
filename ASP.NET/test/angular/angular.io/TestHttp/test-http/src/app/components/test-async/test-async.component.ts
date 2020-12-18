import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { IItemDto } from 'src/app/core/state/item';

@Component({
  selector: 'app-test-async',
  templateUrl: './test-async.component.html',
  styleUrls: ['./test-async.component.css']
})
export class TestAsyncComponent implements OnInit {
  itemsAsyncAndSubscribeTogether: Observable<IItemDto[]>;
  itemsAsync: Observable<IItemDto[]>;
  itemsSubscribe: IItemDto[];
  itemsBehaviorSubject = new BehaviorSubject<IItemDto[]>([]);
  baseUrl = 'http://localhost:53683/api/item';

  constructor(
    private httpClient: HttpClient
  ) {}

  ngOnInit(): void {
  }

  onLoadAsyncAndSubscribeTogetherClick(): void {
    this.itemsAsyncAndSubscribeTogether = this.httpClient.get<IItemDto[]>(this.baseUrl);
    this.itemsAsyncAndSubscribeTogether.subscribe();
  }

  onLoadAsyncClick(): void {
    this.itemsAsync = this.httpClient.get<IItemDto[]>(this.baseUrl);
  }

  onLoadSubscribeClick(): void {
    this.httpClient.get<IItemDto[]>(this.baseUrl)
      .subscribe(items => this.itemsSubscribe = items);
  }

  onLoadBehaviorSubjectClick(): void {
    this.httpClient.get<IItemDto[]>(this.baseUrl)
      .subscribe(items => this.itemsBehaviorSubject.next(items));
  }
}
