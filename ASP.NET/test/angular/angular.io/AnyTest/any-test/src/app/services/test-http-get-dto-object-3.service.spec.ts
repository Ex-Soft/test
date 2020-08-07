import { TestBed } from '@angular/core/testing';

import { TestHttpGetDtoObject3Service } from './test-http-get-dto-object-3.service';

describe('TestHttpGetDtoObject3Service', () => {
  let service: TestHttpGetDtoObject3Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestHttpGetDtoObject3Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
