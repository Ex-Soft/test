import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TestInputOutputComponent } from './test-input-output.component';

describe('TestInputOutputComponent', () => {
  let component: TestInputOutputComponent;
  let fixture: ComponentFixture<TestInputOutputComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TestInputOutputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestInputOutputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
