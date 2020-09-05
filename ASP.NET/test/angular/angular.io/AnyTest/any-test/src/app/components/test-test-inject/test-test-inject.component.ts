// https://angular.io/api/core/InjectionToken
// https://angular.io/guide/dependency-injection-providers

import { Component, OnInit, Inject } from '@angular/core';
import { SmthClass, IAppConfig } from '../../classes';
import { VICTIM_INJECTION_TOKEN, VICTIM_VALUE } from './victim';
import { APP_CONFIG } from '../../app.config';

@Component({
  selector: 'app-test-test-inject',
  templateUrl: './test-test-inject.component.html',
  styleUrls: ['./test-test-inject.component.css']
  // , providers: [{ provide: VICTIM_INJECTION_TOKEN, useValue: VICTIM_VALUE }] // doesn't work in spec.ts
})
export class TestTestInjectComponent implements OnInit {
  name: string;
  p1: string;

  constructor(
    @Inject(VICTIM_INJECTION_TOKEN) public data: SmthClass,
    @Inject(APP_CONFIG) config: IAppConfig
  ) {
    this.name = data.name;
    this.p1 = config.p1;
  }

  ngOnInit(): void {
  }
}
