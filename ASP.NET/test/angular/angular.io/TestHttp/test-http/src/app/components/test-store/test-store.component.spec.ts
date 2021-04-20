import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TestStoreComponent } from './test-store.component';

describe('TestStoreComponent', () => {
  let component: TestStoreComponent;
  let fixture: ComponentFixture<TestStoreComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TestStoreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
