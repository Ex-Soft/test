import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

import { CustomComponentValidationOneComponent } from '../custom-component-validation-one/custom-component-validation-one.component';
import { CustomComponentValidationOneFormComponent } from './custom-component-validation-one-form.component';

describe('CustomComponentValidationOneFormComponent', () => {
  let component: CustomComponentValidationOneFormComponent;
  let fixture: ComponentFixture<CustomComponentValidationOneFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [
        CustomComponentValidationOneComponent,
        CustomComponentValidationOneFormComponent
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
    fixture = TestBed.createComponent(CustomComponentValidationOneFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
