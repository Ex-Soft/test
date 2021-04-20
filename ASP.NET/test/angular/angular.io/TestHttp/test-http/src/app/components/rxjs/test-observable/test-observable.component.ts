import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IItemDto, ItemsQuery, ItemService, ItemsState } from '../../../core/state/item';

@Component({
  selector: 'app-test-observable',
  templateUrl: './test-observable.component.html',
  styleUrls: ['./test-observable.component.css']
})
export class TestObservableComponent implements OnInit {
  constructor(
    private query: ItemsQuery,
    private service: ItemService) {
  }

  ngOnInit(): void {
  }

  onSimpleClick(): void {
    const observable = new Observable(subscriber => {
      subscriber.next(1);
      subscriber.next(2);
      subscriber.next(3);
      setTimeout(() => {
        subscriber.next(4);
        subscriber.complete();
      }, 1000);
    });

    console.log('just before subscribe');
    observable.subscribe({
      next(x): void { console.log('got value ' + x); },
      error(err): void { console.error('something wrong occurred: ' + err); },
      complete(): void { console.log('done'); }
    });
    console.log('just after subscribe');
  }

  onLoadClick(): void {
    const userDefined = () => (source: Observable<ItemsState>) => new Observable<ItemsState>((subscriber) => {
      source.subscribe({
        next: (state: ItemsState): void => {
          const length: number = Array.isArray(state.ids) ? state.ids.length : 0;
          if (!length) {
            this.service.getItems();
          }
          subscriber.next(state);
        },
        error(err): void {
          subscriber.error(err);
        },
        complete(): void {
          subscriber.complete();
        }
      });
    });

    this.query.items$.pipe(userDefined()).subscribe();
  }
}
