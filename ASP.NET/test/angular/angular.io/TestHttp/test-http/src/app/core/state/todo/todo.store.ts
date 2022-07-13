import { Injectable } from '@angular/core';
import { EntityState, EntityStore, StoreConfig, ActiveState } from '@datorama/akita';
import { ITodoDto } from './todo.type';

export interface TodosState extends EntityState<ITodoDto, number>, ActiveState { }

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'todos', idKey: 'id', resettable: true })
export class TodosStore extends EntityStore<TodosState, ITodoDto> {
  constructor() {
    super();

    if (window.console && console.log) {
      console.log('TodosStore.ctor() %o', this.getValue());
    }
  }
}
