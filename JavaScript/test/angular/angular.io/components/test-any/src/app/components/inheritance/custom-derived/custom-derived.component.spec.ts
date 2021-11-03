import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';

import { CustomBaseComponent } from '../custom-base/custom-base.component';
import { CustomDerivedComponent } from './custom-derived.component';

describe('CustomDerivedComponent', () => {
  let component: CustomDerivedComponent;
  let fixture: ComponentFixture<CustomDerivedComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule],
      declarations: [ CustomBaseComponent, CustomDerivedComponent ]
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
