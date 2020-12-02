import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestRadioButtonComponent } from './test-radio-button.component';

describe('TestRadioButtonComponent', () => {
  let component: TestRadioButtonComponent;
  let fixture: ComponentFixture<TestRadioButtonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestRadioButtonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestRadioButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
