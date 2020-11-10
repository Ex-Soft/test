import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestTestInputComponent } from './test-test-input.component';

describe('TestTestInputComponent', () => {
  let component: TestTestInputComponent;
  let fixture: ComponentFixture<TestTestInputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestTestInputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestTestInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
