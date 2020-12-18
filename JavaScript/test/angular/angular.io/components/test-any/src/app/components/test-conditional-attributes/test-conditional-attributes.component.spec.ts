import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TestConditionalAttributesComponent } from './test-conditional-attributes.component';

describe('TestConditionalAttributesComponent', () => {
  let component: TestConditionalAttributesComponent;
  let fixture: ComponentFixture<TestConditionalAttributesComponent>;

  beforeEach(waitForAsync(() => {
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
