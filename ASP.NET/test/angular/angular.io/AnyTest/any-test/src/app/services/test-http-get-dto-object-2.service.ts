import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { TestHttpClientService } from './test-http-client.service';
import { DtoObject2 } from '../models/dto-object2';

@Injectable({
  providedIn: 'root'
})
export class TestHttpGetDtoObject2Service extends TestHttpClientService<DtoObject2> {
  private route = 'getdtoobject2';

  constructor(http: HttpClient) {
    super(http);
  }

  getData(url: string): Observable<DtoObject2> {
    return super.getData(`${url}${this.route}`);
  }
}
