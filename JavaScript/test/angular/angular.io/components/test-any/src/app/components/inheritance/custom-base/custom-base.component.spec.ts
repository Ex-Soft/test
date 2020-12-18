import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { CustomBaseComponent } from './custom-base.component';

describe('CustomBaseComponent', () => {
  let component: CustomBaseComponent;
  let fixture: ComponentFixture<CustomBaseComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomBaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
