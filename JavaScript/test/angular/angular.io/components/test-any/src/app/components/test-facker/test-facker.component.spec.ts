import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestFackerComponent } from './test-facker.component';

describe('TestFackerComponent', () => {
  let component: TestFackerComponent;
  let fixture: ComponentFixture<TestFackerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestFackerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestFackerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
