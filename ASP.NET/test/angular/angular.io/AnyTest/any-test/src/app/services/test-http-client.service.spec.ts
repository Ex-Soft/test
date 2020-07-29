import { TestBed } from '@angular/core/testing';

import { TestHttpClientService } from './test-http-client.service';

describe('TestHttpClientService', () => {
  let service: TestHttpClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestHttpClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
