import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestinputComponent } from './testinput.component';

describe('TestinputComponent', () => {
  let component: TestinputComponent;
  let fixture: ComponentFixture<TestinputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestinputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestinputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
