import { TestBed } from '@angular/core/testing';

import { TestHttpGet1Service } from './test-http-get-1.service';

describe('TestHttpGet1Service', () => {
  let service: TestHttpGet1Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestHttpGet1Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
