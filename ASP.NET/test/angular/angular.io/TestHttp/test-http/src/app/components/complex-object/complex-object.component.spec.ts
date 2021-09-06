import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { of } from 'rxjs';

import { ComplexObjectComponent } from './complex-object.component';
import { IComplexObjectDto, ComplexObjectQuery, ComplexObjectService } from '../../core/state/complex-object';

const complexObjectQuery = jasmine.createSpyObj('ComplexObjectQuery', ['selectAll']);
complexObjectQuery.selectAll.and.returnValue(of([] as IComplexObjectDto[]));

const complexObjectService = jasmine.createSpyObj('ComplexObjectService', ['getComplexObject', 'getComplexObjects']);
complexObjectService.getComplexObject.and.callFake(() => {
  if (window.console && console.log) {
    console.log('getComplexObjectFake()');
  }
});
complexObjectService.getComplexObjects.and.callFake(() => {
  if (window.console && console.log) {
    console.log('getComplexObjectsFake()');
  }
});

describe('ComplexObjectComponent', () => {
  let component: ComplexObjectComponent;
  let fixture: ComponentFixture<ComplexObjectComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ComplexObjectComponent ],
      providers: [
        { provide: ComplexObjectQuery, useValue: complexObjectQuery },
        { provide: ComplexObjectService, useValue: complexObjectService }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComplexObjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
