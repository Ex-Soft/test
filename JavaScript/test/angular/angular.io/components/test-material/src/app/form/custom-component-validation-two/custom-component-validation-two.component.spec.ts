import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomComponentValidationTwoComponent } from './custom-component-validation-two.component';

describe('CustomComponentValidationTwoComponent', () => {
  let component: CustomComponentValidationTwoComponent;
  let fixture: ComponentFixture<CustomComponentValidationTwoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomComponentValidationTwoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomComponentValidationTwoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
