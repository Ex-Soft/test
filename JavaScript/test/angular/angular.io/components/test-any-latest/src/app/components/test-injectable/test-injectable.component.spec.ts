import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestInjectableComponent } from './test-injectable.component';

describe('TestInjectableComponent', () => {
  let component: TestInjectableComponent;
  let fixture: ComponentFixture<TestInjectableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestInjectableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestInjectableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
