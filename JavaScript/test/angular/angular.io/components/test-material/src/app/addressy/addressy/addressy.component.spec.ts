import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

import { AddressyComponent } from './addressy.component';

describe('AddressyComponent', () => {
  let component: AddressyComponent;
  let fixture: ComponentFixture<AddressyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddressyComponent ],
      imports: [
        HttpClientTestingModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        MatInputModule,
        MatIconModule,
        MatAutocompleteModule
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddressyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
