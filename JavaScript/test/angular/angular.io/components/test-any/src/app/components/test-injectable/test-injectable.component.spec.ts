import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestInjectableClassWrapper, TestInjectableClassWithEvents  } from './test-injectable';
import { TestInjectableComponent } from './test-injectable.component';

const testInjectableClassWrapper = {
  PString: 'PString (from mock)',
  PString1: 'PString1 (from mock)',
  PString2: 'PString2 (from mock)',
  PArrayOfString: ['PArrayOfString #0 (from mock)', 'PArrayOfString #1 (from mock)', 'PArrayOfString #2 (from mock)'],
  PArrayOfString1: ['PArrayOfString1 #0 (from mock)', 'PArrayOfString1 #1 (from mock)', 'PArrayOfString1 #2 (from mock)'],
  PArrayOfString2: ['PArrayOfString2 #0 (from mock)', 'PArrayOfString2 #1 (from mock)', 'PArrayOfString2 #2 (from mock)']
};

const testInjectableClassWithEvents = {
  on: () => {}
};

describe('TestInjectableComponent', () => {
  let component: TestInjectableComponent;
  let fixture: ComponentFixture<TestInjectableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestInjectableComponent ],
      providers: [
        { provide: TestInjectableClassWrapper, useValue: testInjectableClassWrapper },
        { provide: TestInjectableClassWithEvents, useValue: testInjectableClassWithEvents }
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestInjectableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
    expect(component.PString).toBe('PString (from mock)');
    expect(component.PString1).toBe('PString1 (from mock)');
    expect(component.PString2).toBe('PString2 (from mock)');
    expect(component.PArrayOfString).toEqual(jasmine.arrayContaining(['PArrayOfString #2 (from mock)', 'PArrayOfString #1 (from mock)', 'PArrayOfString #0 (from mock)']));
    expect(component.PArrayOfString1).toEqual(jasmine.arrayContaining(['PArrayOfString1 #2 (from mock)', 'PArrayOfString1 #1 (from mock)', 'PArrayOfString1 #0 (from mock)']));
    expect(component.PArrayOfString2).toEqual(jasmine.arrayContaining(['PArrayOfString2 #2 (from mock)', 'PArrayOfString2 #1 (from mock)', 'PArrayOfString2 #0 (from mock)']));
  });
});
