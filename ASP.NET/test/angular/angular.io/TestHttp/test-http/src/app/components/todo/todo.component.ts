import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { TodoDtoToViewPipe } from '../../pipes/todo-dto-to-view.pipe';
import { TodosQuery, TodoService, TodosStore, ITodoDto, ITodoGroupDto, ITodoGroupItemDto, createTodo } from '../../core/state/todo';
import { ITodoView } from '../../models/ITodoView';
import { Order } from '@datorama/akita';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit, OnDestroy {
  destroy$: Subject<boolean> = new Subject<boolean>();
  todoDto: ITodoDto;
  todoDtos: ITodoDto[];
  todo: ITodoView;

  constructor(private query: TodosQuery, private service: TodoService, private store: TodosStore) { }

  ngOnInit(): void {
    this.query.state$
      .pipe(takeUntil(this.destroy$))
      .subscribe(state => {
        console.log(state);
        if (state.ids.length) {
          this.query.selectFirst().subscribe(result => {
            if (result) {
              const pipe = new TodoDtoToViewPipe();
              this.todo = pipe.transform(this.todoDto = result);
            }
          });

          this.query.selectAll().subscribe(result => {
              this.todoDtos = result;
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
    console.log(this.query.getAll({ sortBy: 'id', sortByOrder: Order.DESC }));
  }

  onClickUpdate(): void {
    if (this.todoDto) {
      console.log(this.todoDto);

      let newTodo;

      // newTodo = { ...this.todoDto } as ITodoDto;
      // newTodo = Object.assign({}, this.todoDto);
      // newTodo = createTodo(this.todoDto);
      newTodo = JSON.parse(JSON.stringify(this.todoDto));
      newTodo.groups[0].items.splice(1, 2);
      newTodo.groups[1].items.splice(2, 1);
      newTodo.groups.push({
        id: 3,
        name: 'Todo #1 (update) Group #3 (update)',
        items: [
          { id: 31, name: 'Todo #1 (update) Group #3 (update) Item 1 (update)' } as ITodoGroupItemDto,
          { id: 32, name: 'Todo #1 (update) Group #3 (update) Item 2 (update)' } as ITodoGroupItemDto,
          { id: 33, name: 'Todo #1 (update) Group #3 (update) Item 3 (update)' } as ITodoGroupItemDto,
        ] as ITodoGroupItemDto[]
      } as ITodoGroupDto);
      this.store.update(newTodo.id, newTodo);

      newTodo = {
        id: 3,
        name: 'Todo #2 (update)',
        groups: [
          {
            id: 1,
            name: 'Todo #2 (update) Group #1 (update)',
            items: [
              { id: 11, name: 'Todo #2 (update) Group #1 (update) Item 1 (update)' } as ITodoGroupItemDto,
            ] as ITodoGroupItemDto[]
          } as ITodoGroupDto,
          {
            id: 2,
            name: 'Todo #2 (update) Group #2 (update)',
            items: [
              { id: 21, name: 'Todo #2 (update) Group #2 (update) Item 1 (update)' } as ITodoGroupItemDto,
              { id: 22, name: 'Todo #2 (update) Group #2 (update) Item 2 (update)' } as ITodoGroupItemDto,
            ] as ITodoGroupItemDto[]
          } as ITodoGroupDto,
          {
            id: 3,
            name: 'Todo #2 (update) Group #3 (update)',
            items: [
              { id: 31, name: 'Todo #3 (update) Group #3 (update) Item 1 (update)' } as ITodoGroupItemDto,
              { id: 32, name: 'Todo #3 (update) Group #3 (update) Item 2 (update)' } as ITodoGroupItemDto,
              { id: 33, name: 'Todo #3 (update) Group #3 (update) Item 3 (update)' } as ITodoGroupItemDto,
            ] as ITodoGroupItemDto[]
          } as ITodoGroupDto
        ] as ITodoGroupDto[]
      } as ITodoDto;

      this.store.update(3, newTodo);

      console.log(this.todoDto);
    }
  }
}
