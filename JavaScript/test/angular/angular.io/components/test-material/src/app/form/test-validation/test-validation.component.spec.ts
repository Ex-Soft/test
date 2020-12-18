import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogRef } from '@angular/material/dialog';

import { TestValidationComponent } from './test-validation.component';

describe('TestValidationComponent', () => {
  let component: TestValidationComponent;
  let fixture: ComponentFixture<TestValidationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestValidationComponent ],
      providers: [
        { provide: MatDialogRef, useValue: {} }
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestValidationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
