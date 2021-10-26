import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogContent, MatDialogActions } from '@angular/material/dialog';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { TestRadioButtonComponent } from './test-radio-button.component';

describe('TestRadioButtonComponent', () => {
  let component: TestRadioButtonComponent;
  let fixture: ComponentFixture<TestRadioButtonComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [
        TestRadioButtonComponent,
        MatDialogContent,
        MatDialogActions,
        MatProgressSpinner
      ],
      imports: [ HttpClientTestingModule ],
      providers: [
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: {} }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestRadioButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
