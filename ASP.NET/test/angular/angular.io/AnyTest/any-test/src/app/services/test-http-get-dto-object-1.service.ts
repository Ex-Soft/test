import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { TestHttpClientService } from './test-http-client.service';
import { DtoObject1 } from '../models/dto-object1';

@Injectable({
  providedIn: 'root'
})
export class TestHttpGetDtoObject1Service extends TestHttpClientService<DtoObject1> {
  private route = 'getdtoobject1';

  constructor(http: HttpClient) {
    super(http);
  }

  getData(url: string): Observable<DtoObject1> {
    return super.getData(`${url}${this.route}`);
  }
}
