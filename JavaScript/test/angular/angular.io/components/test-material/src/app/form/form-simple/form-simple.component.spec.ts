import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogRef } from '@angular/material/dialog';

import { FormSimpleComponent } from './form-simple.component';

describe('FormSimpleComponent', () => {
  let component: FormSimpleComponent;
  let fixture: ComponentFixture<FormSimpleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormSimpleComponent ],
      providers: [
        { provide: MatDialogRef, useValue: {} }
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormSimpleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
