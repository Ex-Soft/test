import { TestBed } from '@angular/core/testing';

import { TestHttpGet2Service } from './test-http-get-2.service';

describe('TestHttpGet2Service', () => {
  let service: TestHttpGet2Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestHttpGet2Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
