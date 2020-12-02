import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { DialogWrapperComponent } from './dialog-wrapper.component';

describe('DialogWrapperComponent', () => {
  let component: DialogWrapperComponent;
  let fixture: ComponentFixture<DialogWrapperComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogWrapperComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogWrapperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
