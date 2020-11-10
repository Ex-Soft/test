import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestRadiobuttonComponent } from './testradiobutton.component';
import { CustomFilterPipe } from '../../pipes/custom-filter.pipe';

describe('TestradiobuttonComponent', () => {
  let component: TestRadiobuttonComponent;
  let fixture: ComponentFixture<TestRadiobuttonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestRadiobuttonComponent, CustomFilterPipe ]
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
