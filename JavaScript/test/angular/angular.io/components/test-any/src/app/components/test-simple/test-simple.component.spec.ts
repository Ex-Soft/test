import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestSimpleComponent } from './test-simple.component';

describe('TestSimpleComponent', () => {
  let component: TestSimpleComponent;
  let fixture: ComponentFixture<TestSimpleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestSimpleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestSimpleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
