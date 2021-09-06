import { ApplicationModule } from '@angular/core';
import { TestBed, waitForAsync } from '@angular/core/testing';
import { AppComponent } from './app.component';

import { AppModule } from './app.module';

import { ComplexObjectService } from './core/state/complex-object';
import { ItemWithEnumService } from './core/state/item-with-enum';
import { TodoService } from './core/state/todo';

const complexObjectService = jasmine.createSpyObj('ComplexObjectService', ['getComplexObject', 'getComplexObjects']);
complexObjectService.getComplexObject.and.callFake(() => {
  if (window.console && console.log) {
    console.log('getComplexObjectFake() (app)');
  }
});
complexObjectService.getComplexObjects.and.callFake(() => {
  if (window.console && console.log) {
    console.log('getComplexObjectsFake() (app)');
  }
});

const itemWithEnumService = jasmine.createSpyObj('ItemWithEnumService', ['getItemsWithEnum']);
const todoService = jasmine.createSpyObj('TodoService', ['getTodo', 'getTodos']);

describe('AppComponent', () => {
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent
      ],
      imports: [
        ApplicationModule,
        AppModule
      ],
      providers: [
        { provide: ComplexObjectService, useValue: complexObjectService },
        { provide: ItemWithEnumService, useValue: itemWithEnumService },
        { provide: TodoService, useValue: todoService }
      ]
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'test-http'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('test-http');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('span.content').textContent).toContain('test-http app is running!');
  });
});
