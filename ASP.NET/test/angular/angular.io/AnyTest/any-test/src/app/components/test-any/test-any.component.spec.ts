import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TestAnyComponent } from './test-any.component';

describe('TestAnyComponent', () => {
  let component: TestAnyComponent;
  let fixture: ComponentFixture<TestAnyComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TestAnyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestAnyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
