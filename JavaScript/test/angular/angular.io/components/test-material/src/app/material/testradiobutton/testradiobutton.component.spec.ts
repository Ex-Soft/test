import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestRadiobuttonComponent } from './testradiobutton.component';

describe('TestradiobuttonComponent', () => {
  let component: TestRadiobuttonComponent;
  let fixture: ComponentFixture<TestRadiobuttonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestRadiobuttonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestRadiobuttonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
