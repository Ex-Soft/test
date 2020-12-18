import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { CustomDerivedComponent } from './custom-derived.component';

describe('CustomDerivedComponent', () => {
  let component: CustomDerivedComponent;
  let fixture: ComponentFixture<CustomDerivedComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomDerivedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomDerivedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
