import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TestSliderComponent } from './testslider.component';

describe('TestsliderComponent', () => {
  let component: TestSliderComponent;
  let fixture: ComponentFixture<TestSliderComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TestSliderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestSliderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
