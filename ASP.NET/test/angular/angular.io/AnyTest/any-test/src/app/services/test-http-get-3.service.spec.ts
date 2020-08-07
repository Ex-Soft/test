import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';

import { TestHttpGet3Service } from './test-http-get-3.service';

describe('TestHttpGet3Service', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;
  let service: TestHttpGet3Service<any>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });

    httpClient = TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);
    service = new TestHttpGet3Service<any>(httpClient);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
