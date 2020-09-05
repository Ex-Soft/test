import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComplexObjectComponent } from './complex-object.component';

describe('ComplexObjectComponent', () => {
  let component: ComplexObjectComponent;
  let fixture: ComponentFixture<ComplexObjectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComplexObjectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComplexObjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
