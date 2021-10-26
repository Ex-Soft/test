import { Component, OnInit } from '@angular/core';
import { TodosQuery } from 'src/app/core/state/todo';

@Component({
  selector: 'app-test-unit-test',
  templateUrl: './test-unit-test.component.html',
  styleUrls: ['./test-unit-test.component.css']
})
export class TestUnitTestComponent implements OnInit {
  o: unknown;
  id$ = this.todosQuery.selectActive(todo => {
    return todo.id;
  });

  constructor(private todosQuery: TodosQuery) {}

  ngOnInit(): void {
    this.o = { id: 1, value: 'value# 1' };
  }
}
