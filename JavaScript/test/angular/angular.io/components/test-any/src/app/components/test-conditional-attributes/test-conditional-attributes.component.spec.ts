import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestConditionalAttributesComponent } from './test-conditional-attributes.component';

describe('TestConditionalAttributesComponent', () => {
  let component: TestConditionalAttributesComponent;
  let fixture: ComponentFixture<TestConditionalAttributesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestConditionalAttributesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestConditionalAttributesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
