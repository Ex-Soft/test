import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestAsyncComponent } from './test-async.component';

describe('TestAsyncComponent', () => {
  let component: TestAsyncComponent;
  let fixture: ComponentFixture<TestAsyncComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestAsyncComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestAsyncComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
