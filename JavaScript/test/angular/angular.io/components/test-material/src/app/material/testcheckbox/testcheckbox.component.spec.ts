import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TestCheckboxComponent } from './testcheckbox.component';

describe('TestcheckboxComponent', () => {
  let component: TestCheckboxComponent;
  let fixture: ComponentFixture<TestCheckboxComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TestCheckboxComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestCheckboxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
