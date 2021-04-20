import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomComponentValidationOneComponent } from './custom-component-validation-one.component';

describe('CustomComponentValidationOneComponent', () => {
  let component: CustomComponentValidationOneComponent;
  let fixture: ComponentFixture<CustomComponentValidationOneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomComponentValidationOneComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomComponentValidationOneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
