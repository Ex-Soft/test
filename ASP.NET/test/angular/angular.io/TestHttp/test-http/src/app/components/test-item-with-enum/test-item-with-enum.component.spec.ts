import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestItemWithEnumComponent } from './test-item-with-enum.component';

describe('TestItemWithEnumComponent', () => {
  let component: TestItemWithEnumComponent;
  let fixture: ComponentFixture<TestItemWithEnumComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestItemWithEnumComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestItemWithEnumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
