import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalDerivedComponent } from './modal-derived.component';

describe('ModalDerivedComponent', () => {
  let component: ModalDerivedComponent;
  let fixture: ComponentFixture<ModalDerivedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalDerivedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalDerivedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
