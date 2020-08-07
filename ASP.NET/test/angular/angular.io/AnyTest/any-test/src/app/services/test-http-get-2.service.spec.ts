import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';

import { TestHttpGet2Service } from './test-http-get-2.service';

describe('TestHttpGet2Service', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;

  let service: TestHttpGet2Service<any>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });

    httpClient = TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);
    service = new TestHttpGet2Service<any>(httpClient);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
