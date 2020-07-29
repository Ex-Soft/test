import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestlistitemsComponent } from './testlistitems.component';

describe('TestlistitemsComponent', () => {
  let component: TestlistitemsComponent;
  let fixture: ComponentFixture<TestlistitemsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestlistitemsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestlistitemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
