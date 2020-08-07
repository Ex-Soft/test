import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';

import { TestHttpGet1Service } from './test-http-get-1.service';

describe('TestHttpGet1Service', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;
  let service: TestHttpGet1Service<any>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });

    httpClient = TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);
    service = new TestHttpGet1Service<any>(httpClient);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
