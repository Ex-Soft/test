import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestIconComponent } from './testicon.component';

describe('TestIconComponent', () => {
  let component: TestIconComponent;
  let fixture: ComponentFixture<TestIconComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestIconComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
