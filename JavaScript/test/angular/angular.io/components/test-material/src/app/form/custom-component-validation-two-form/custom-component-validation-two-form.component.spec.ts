import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

import { CustomComponentValidationTwoComponent } from '../custom-component-validation-two/custom-component-validation-two.component';
import { CustomComponentValidationTwoFormComponent } from './custom-component-validation-two-form.component';

describe('CustomComponentValidationTwoFormComponent', () => {
  let component: CustomComponentValidationTwoFormComponent;
  let fixture: ComponentFixture<CustomComponentValidationTwoFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [
        CustomComponentValidationTwoComponent,
        CustomComponentValidationTwoFormComponent
      ],
      imports: [
        FormsModule,
        ReactiveFormsModule
      ],
      providers: [
        { provide: MatDialogRef, useValue: {} }
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomComponentValidationTwoFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
