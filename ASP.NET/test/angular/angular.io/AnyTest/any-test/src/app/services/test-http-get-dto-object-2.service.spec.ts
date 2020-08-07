import { TestBed } from '@angular/core/testing';

import { TestHttpGetDtoObject2Service } from './test-http-get-dto-object-2.service';

describe('TestHttpGetDtoObject2Service', () => {
  let service: TestHttpGetDtoObject2Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestHttpGetDtoObject2Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
