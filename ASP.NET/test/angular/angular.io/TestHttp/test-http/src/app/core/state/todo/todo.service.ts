import { Injectable } from '@angular/core';
import { tap, finalize } from 'rxjs/operators';
import { createTodo, createTodos } from './todo.type';
import { TodosStore } from './todo.store';
import { TodoDataService } from './todo-data.service';

@Injectable({ providedIn: 'root' })
export class TodoService {
  constructor(private store: TodosStore, private dataService: TodoDataService) {}

  getTodo(id: number): void {
    this.dataService
      .getTodo(id)
      .pipe(
        tap(todo => {
          this.store.add(createTodo(todo));
      })).subscribe(
        () => {},
        err => {
          this.store.setError(err.status);
        }
      );
  }

  getTodos(): void {
    this.store.setLoading(true);
    this.dataService
      .getTodos()
      .pipe(
        finalize(() => {
          this.store.setLoading(false);
        }),
        tap(todos => {
          this.store.add(createTodos(todos));
        })
      )
      .subscribe();
  }
}
