import { Injectable } from '@angular/core';
import { QueryEntity } from '@datorama/akita';
import { TodosState, TodosStore } from './todo.store';
import { ITodoDto } from './todo.type';

@Injectable({ providedIn: 'root' })
export class TodosQuery extends QueryEntity<TodosState, ITodoDto> {
  /*todos$ = this.selectAll();
  todos = this.getAll();*/
  state$ = this.select(state => state);

  constructor(protected store: TodosStore) {
    super(store);
  }
}
