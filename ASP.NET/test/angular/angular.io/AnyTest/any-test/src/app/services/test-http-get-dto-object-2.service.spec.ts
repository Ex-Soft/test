import { TestBed } from '@angular/core/testing';

import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';

import { TestHttpGetDtoObject2Service } from './test-http-get-dto-object-2.service';

describe('TestHttpGetDtoObject2Service', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;
  let service: TestHttpGetDtoObject2Service;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });

    httpClient = TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);

    service = TestBed.inject(TestHttpGetDtoObject2Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
