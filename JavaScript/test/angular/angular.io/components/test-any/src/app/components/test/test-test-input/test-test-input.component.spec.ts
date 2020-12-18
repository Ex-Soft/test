import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TestTestInputComponent } from './test-test-input.component';
import { SmthItemComponent } from './smth-item/smth-item.component';

describe('TestTestInputComponent', () => {
  let component: TestTestInputComponent;
  let fixture: ComponentFixture<TestTestInputComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [
        TestTestInputComponent,
        SmthItemComponent
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestTestInputComponent);
    component = fixture.componentInstance;
    component.items = [];
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
