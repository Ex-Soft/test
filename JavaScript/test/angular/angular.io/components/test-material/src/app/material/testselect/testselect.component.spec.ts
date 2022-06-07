import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestSelectComponent } from './testselect.component';

describe('TestSelectComponent', () => {
  let component: TestSelectComponent;
  let fixture: ComponentFixture<TestSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestSelectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
