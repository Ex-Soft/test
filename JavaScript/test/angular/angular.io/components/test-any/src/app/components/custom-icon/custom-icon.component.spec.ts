import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomIconComponent } from './custom-icon.component';

describe('CustomIconComponent', () => {
  let component: CustomIconComponent;
  let fixture: ComponentFixture<CustomIconComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomIconComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
