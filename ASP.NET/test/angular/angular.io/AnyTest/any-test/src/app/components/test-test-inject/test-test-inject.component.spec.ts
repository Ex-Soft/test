import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Injector } from '@angular/core';

import { TestTestInjectComponent } from './test-test-inject.component';
import { VICTIM_INJECTION_TOKEN } from './victim';
import { SmthClass } from '../../classes';
import { IAppConfig } from '../../classes/iapp-config';
import { APP_CONFIG } from '../../app.config';

const dataMockSmthClass: SmthClass = new SmthClass('dataMockSmthClass');
const dataMockAppConfig: IAppConfig = { p1: 'dataMockAppConfig' };

describe('TestTestInjectComponent', () => {
  let component: TestTestInjectComponent;
  let fixture: ComponentFixture<TestTestInjectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestTestInjectComponent ],
      providers: [
        { provide: VICTIM_INJECTION_TOKEN, useValue: dataMockSmthClass },
        { provide: APP_CONFIG, useValue: dataMockAppConfig }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestTestInjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize SmthClass', () => {
    const injectorSmthClass = Injector.create({providers: [{ provide: VICTIM_INJECTION_TOKEN, useValue: dataMockSmthClass }]});
    const data = injectorSmthClass.get(VICTIM_INJECTION_TOKEN);
    expect(data.name).toEqual('dataMockSmthClass');
    expect(component.name).toEqual('dataMockSmthClass');
  });

  it('should initialize IAppConfig', () => {
    const injectorAppConfig = Injector.create({providers: [{ provide: APP_CONFIG, useValue: dataMockAppConfig }]});
    const config = injectorAppConfig.get(APP_CONFIG);
    expect(config.p1).toEqual('dataMockAppConfig');
    expect(component.p1).toEqual('dataMockAppConfig');
  });
});
