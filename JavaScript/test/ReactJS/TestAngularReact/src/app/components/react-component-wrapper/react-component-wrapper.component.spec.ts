import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReactComponentWrapperComponent } from './react-component-wrapper.component';

describe('ReactComponentWrapperComponent', () => {
  let component: ReactComponentWrapperComponent;
  let fixture: ComponentFixture<ReactComponentWrapperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReactComponentWrapperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReactComponentWrapperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
