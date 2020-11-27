import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomButtonSimpleComponent } from './custom-button-simple.component';

describe('CustomButtonSimpleComponent', () => {
  let component: CustomButtonSimpleComponent;
  let fixture: ComponentFixture<CustomButtonSimpleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomButtonSimpleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomButtonSimpleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
