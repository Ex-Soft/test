import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';

import { TestHttpClientService } from './test-http-client.service';

describe('TestHttpClientService', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;
  let service: TestHttpClientService<any>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });

    httpClient = TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);
    service = new TestHttpClientService<any>(httpClient);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
