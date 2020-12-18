import { TestBed } from '@angular/core/testing';

import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';

import { TestHttpGetDtoObject3Service } from './test-http-get-dto-object-3.service';

describe('TestHttpGetDtoObject3Service', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;
  let service: TestHttpGetDtoObject3Service;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });

    httpClient = TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);

    service = TestBed.inject(TestHttpGetDtoObject3Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
