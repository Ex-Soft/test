import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogRef } from '@angular/material/dialog';

import { AddressyModalComponent } from './addressy-modal.component';

describe('AddressyModalComponent', () => {
  let component: AddressyModalComponent;
  let fixture: ComponentFixture<AddressyModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddressyModalComponent ],
      providers: [
        { provide: MatDialogRef, useValue: {} }
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddressyModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
