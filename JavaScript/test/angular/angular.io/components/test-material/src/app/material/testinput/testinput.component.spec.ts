import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TestinputComponent } from './testinput.component';

describe('TestinputComponent', () => {
  let component: TestinputComponent;
  let fixture: ComponentFixture<TestinputComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TestinputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestinputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
