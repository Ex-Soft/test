import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { TestHttpClientService } from './test-http-client.service';
import { DtoObject3 } from '../models/dto-object3';

@Injectable({
  providedIn: 'root'
})
export class TestHttpGetDtoObject3Service extends TestHttpClientService<DtoObject3> {
  private route = 'getdtoobject3';

  constructor(http: HttpClient) {
    super(http);
  }

  getData(url: string): Observable<DtoObject3> {
    return super.getData(`${url}${this.route}`);
  }
}
