// https://jasmine.github.io/tutorials/spying_on_properties

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WithDataServiceComponent } from './with-data-service.component';
import { IData } from '../components.type';
import { DataService } from '../../services/data-service/data-service';

describe('WithDataServiceComponent', () => {
  let component: WithDataServiceComponent;
  let fixture: ComponentFixture<WithDataServiceComponent>;
  let spyDataService: jasmine.SpyObj<DataService> | undefined | null;

  beforeEach(async () => {
    console.log("beforeEach(async () => {}) %o", spyDataService);

    spyDataService = jasmine.createSpyObj<DataService>("DataService", [], ["data"]);

    await TestBed.configureTestingModule({
      declarations: [ WithDataServiceComponent ],
      providers: [ { provide: DataService, useValue: spyDataService } ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    console.log("beforeEach(() => {}) %o", spyDataService);
    
    fixture = TestBed.createComponent(WithDataServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  afterEach(async () => {
    console.log("afterEach(async () => {}) %o", spyDataService);
    spyDataService = undefined;
  });

  afterEach(() => {
    console.log("afterEach(() => {}) %o", spyDataService);
    spyDataService = undefined;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should be 1', () => {
    (Object.getOwnPropertyDescriptor(spyDataService, "data")?.get as jasmine.Spy<() => IData>).and.returnValue({ pNumber: 1 });
    expect(component.pNumber).toBe(1);
  });

  it('should be 2', () => {
    (Object.getOwnPropertyDescriptor(spyDataService, "data")?.get as jasmine.Spy<() => IData>).and.returnValue({ pNumber: 2 });
    expect(component.pNumber).toBe(2);
  });
});
