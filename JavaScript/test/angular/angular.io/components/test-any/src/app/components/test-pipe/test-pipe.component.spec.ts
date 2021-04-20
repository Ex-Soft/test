import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TestPipeComponent } from './test-pipe.component';

import { IView } from '../../models/IView';
import { IComplexObjectView } from '../../models/IComplexObjectView';

describe('TestPipeComponent', () => {
  let component: TestPipeComponent;
  let fixture: ComponentFixture<TestPipeComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TestPipeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestPipeComponent);
    component = fixture.componentInstance;

    component.complexObject = {} as IComplexObjectView;
    component.items = [] as IView[];

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
