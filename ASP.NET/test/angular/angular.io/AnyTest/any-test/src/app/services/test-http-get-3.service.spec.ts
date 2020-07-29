import { TestBed } from '@angular/core/testing';

import { TestHttpGet3Service } from './test-http-get-3.service';

describe('TestHttpGet3Service', () => {
  let service: TestHttpGet3Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestHttpGet3Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
