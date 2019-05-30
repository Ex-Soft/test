import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestcomboboxComponent } from './testcombobox.component';

describe('TestcomboboxComponent', () => {
  let component: TestcomboboxComponent;
  let fixture: ComponentFixture<TestcomboboxComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestcomboboxComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestcomboboxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
