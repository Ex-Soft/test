import { TestBed, waitForAsync } from '@angular/core/testing';
import { of } from 'rxjs';

import { TodosQuery } from 'src/app/core/state/todo';
import { TostringPipe } from 'src/app/pipes/tostring.pipe';

import { TestUnitTestComponent } from './test-unit-test.component';

describe('TestUnitTestComponent', () => {
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: TodosQuery,
          useValue: jasmine.createSpyObj('TodosQuery', ['selectActive'])
        }
      ],
      declarations: [
        TestUnitTestComponent,
        TostringPipe
      ]
    });
  }));

  it('id is shown', () => {
    const todosQuery = TestBed.inject(TodosQuery) as jasmine.SpyObj<TodosQuery>;
    todosQuery.selectActive.and.returnValue(of(1));
    const fixture = TestBed.createComponent(TestUnitTestComponent);
    const component = fixture.componentInstance;
    fixture.detectChanges();
    const compiled = fixture.nativeElement;

    const actual = compiled.querySelector('span.testUnitTestId').textContent;

    expect(actual).toBe('1');
  });

  it('id isn\'t shown', () => {
    const todosQuery = TestBed.inject(TodosQuery) as jasmine.SpyObj<TodosQuery>;
    todosQuery.selectActive.and.returnValue(of(undefined));
    const fixture = TestBed.createComponent(TestUnitTestComponent);
    const component = fixture.componentInstance;
    fixture.detectChanges();
    const compiled = fixture.nativeElement;

    const actual = compiled.querySelector('span.testUnitTestId').textContent;

    expect(actual).toBe('');
  });

  it('tostring pipe works', () => {
    const fixture = TestBed.createComponent(TestUnitTestComponent);
    const component = fixture.componentInstance;
    const o = { id: 1, value: 'test value# 1' };
    fixture.detectChanges(); // component doesn't have o -> component.o = { id: 1, value: 'value# 1' } via ngOnInit()
    component.o = o; // component.o = { id: 1, value: 'value# 1' } -> component.o = { id: 1, value: 'test value# 1' }
    fixture.detectChanges(); // update layout
    const compiled = fixture.nativeElement;

    const actual = compiled.querySelector('span.testUnitTestPipe').textContent;

    expect(actual).toBe(JSON.stringify(o));
  });
});
