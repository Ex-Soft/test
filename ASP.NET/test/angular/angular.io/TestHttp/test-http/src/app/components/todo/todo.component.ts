import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { TodoDtoToViewPipe } from '../../pipes/todo-dto-to-view.pipe';
import { TodosQuery, TodoService, ITodoDto } from '../../core/state/todo';
import { ITodoView } from '../../models/ITodoView';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit, OnDestroy {
  destroy$: Subject<boolean> = new Subject<boolean>();
  todo: ITodoView;

  constructor(private query: TodosQuery, private service: TodoService) { }

  ngOnInit(): void {
    this.query.state$
      .pipe(takeUntil(this.destroy$))
      .subscribe(state => {
        console.log(state);
        if (state.ids.length) {
          this.query.selectFirst().subscribe(result => {
            const pipe = new TodoDtoToViewPipe();
            this.todo = pipe.transform(result);
          });
        }
      });

    this.service.getTodos();
  }

  ngOnDestroy(): void {
    this.destroy$.next(true);
    // Unsubscribe from the subject
    this.destroy$.unsubscribe();
  }

  onClickGetTodos(): void {
    this.service.getTodos();
  }

  onClickSelectAll(): void {
    this.query.selectAll().subscribe(result => {
      console.log(result);
    });
  }

  onClickGetAll(): void {
    console.log(this.query.getAll());
  }
}
