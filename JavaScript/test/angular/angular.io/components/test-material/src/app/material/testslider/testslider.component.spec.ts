import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestSliderComponent } from './testslider.component';

describe('TestsliderComponent', () => {
  let component: TestSliderComponent;
  let fixture: ComponentFixture<TestSliderComponent>;

  beforeEach(async(() => {
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
