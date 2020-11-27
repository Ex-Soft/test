import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomBaseComponent } from './custom-base.component';

describe('CustomBaseComponent', () => {
  let component: CustomBaseComponent;
  let fixture: ComponentFixture<CustomBaseComponent>;

  beforeEach(async(() => {
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
