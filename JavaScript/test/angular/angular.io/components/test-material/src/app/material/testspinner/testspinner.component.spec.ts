import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestspinnerComponent } from './testspinner.component';

describe('TestspinnerComponent', () => {
  let component: TestspinnerComponent;
  let fixture: ComponentFixture<TestspinnerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestspinnerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestspinnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
