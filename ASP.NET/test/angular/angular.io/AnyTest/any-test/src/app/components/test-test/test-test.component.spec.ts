import { ComponentFixture, ComponentFixtureAutoDetect, TestBed, waitForAsync } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Observable, of } from 'rxjs';

import { TestTestComponent } from './test-test.component';
import { TestHttpGetDtoObject1Service } from '../../services/test-http-get-dto-object-1.service';
import { TestHttpGetDtoObject2Service } from '../../services/test-http-get-dto-object-2.service';
import { DtoObject1 } from 'src/app/models/dto-object1';
import { DtoObject2 } from 'src/app/models/dto-object2';

describe('TestTestComponent', () => {
  let component: TestTestComponent;
  let fixture: ComponentFixture<TestTestComponent>;
  let nativeElement: HTMLElement;
  let inpTypeText: HTMLInputElement;
  let service1: TestHttpGetDtoObject1Service;
  let service1Stub: Partial<TestHttpGetDtoObject1Service>;
  let service2: any;
  let getDataSpy: any;

  service1Stub = {
    getData(url: string): Observable<DtoObject1> {
      return of( { name: 'name (from stub)' } as DtoObject1);
    }
  };

  beforeEach(waitForAsync(() => {
    console.log('beforeEach(async(() => {}))');
    service2 = jasmine.createSpyObj('TestHttpGetDtoObject2Service', [ 'getData' ]);
    getDataSpy = service2.getData.and.returnValue(of( { name: 'name (from spy)' } as DtoObject2 ));

    TestBed.configureTestingModule({
      declarations: [ TestTestComponent ],
      imports: [
        FormsModule,
        ReactiveFormsModule
      ],
      providers: [
        { provide: ComponentFixtureAutoDetect, useValue: true },
        { provide: TestHttpGetDtoObject1Service, useValue: service1Stub },
        { provide: TestHttpGetDtoObject2Service, useValue: service2 }
      ]
    })
    .compileComponents()
    .then(() => {
      console.log('.compileComponents().then()');
    });
  }));

  beforeEach(() => {
    console.log('beforeEach(() => {})');

    fixture = TestBed.createComponent(TestTestComponent);
    component = fixture.componentInstance;
    component.value1 = 'value1 (from beforeEach())';
    component.value2 = 'value2 (from beforeEach())';
    nativeElement = fixture.nativeElement;
    inpTypeText = nativeElement.querySelector('input[type=\"text\"]');

    service1 = TestBed.inject(TestHttpGetDtoObject1Service);

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should change on ui via binding', () => {
    fixture.detectChanges();
    component.value1 = 'value (from component)';
    fixture.detectChanges();
    expect(inpTypeText.value).toEqual('value (from component)');
  });

  it('should change inside component via binding', () => {
    inpTypeText.value = 'value (from ui)';
    inpTypeText.dispatchEvent(new Event('input'));
    fixture.detectChanges();
    expect(component.value1).toEqual('value (from ui)');
  });

  it('should change on ui via click -> binding', () => {
    fixture.detectChanges();
    component.onBtnSetValue1Click();
    fixture.detectChanges();
    expect(inpTypeText.value).toEqual('value1 (via onBtnSetValue1Click())');
  });

  it('test service via stub', () => {
    let dtoObj: DtoObject1;

    service1.getData('blah-blah-blah').subscribe(obj => {
      dtoObj = obj;
    });

    expect(dtoObj.name).toEqual('name (from stub)');
  });

  it('test service via jasmine.createSpyObj()', () => {
    let dtoObj: DtoObject2;

    getDataSpy().subscribe((obj: DtoObject2) => {
      dtoObj = obj;
    });

    expect(dtoObj.name).toEqual('name (from spy)');
  });
});
