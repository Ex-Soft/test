import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestInputComponent } from './test-input.component';

describe('TestInputComponent', () => {
  let component: TestInputComponent;
  let fixture: ComponentFixture<TestInputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestInputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
