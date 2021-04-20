import { TestBed } from '@angular/core/testing';

import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';

import { TestHttpGetDtoObject1Service } from './test-http-get-dto-object-1.service';

describe('TestHttpGetDtoObject1Service', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;
  let service: TestHttpGetDtoObject1Service;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });

    httpClient = TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);

    service = TestBed.inject(TestHttpGetDtoObject1Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
