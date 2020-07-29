import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { TestHttpClientService } from './test-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class TestHttpGet1Service<T> extends TestHttpClientService<T> {
  private route = 'get1';

  constructor(http: HttpClient) {
    super(http);
  }

  getData(url: string): Observable<T> {
    return super.getData(`${url}${this.route}`);
  }
}
