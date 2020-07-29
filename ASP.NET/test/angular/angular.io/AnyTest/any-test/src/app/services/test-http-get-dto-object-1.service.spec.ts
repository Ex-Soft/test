import { TestBed } from '@angular/core/testing';

import { TestHttpGetDtoObject1Service } from './test-http-get-dto-object-1.service';

describe('TestHttpGetDtoObject1Service', () => {
  let service: TestHttpGetDtoObject1Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestHttpGetDtoObject1Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
