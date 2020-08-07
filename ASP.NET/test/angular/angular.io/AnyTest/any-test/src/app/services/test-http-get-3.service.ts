import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { TestHttpClientService } from './test-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class TestHttpGet3Service<T> extends TestHttpClientService<T> {
  private route = 'get3';

  constructor(http: HttpClient) {
    super(http);
  }

  getData(url: string): Observable<T> {
    return super.getData(`${url}${this.route}`);
  }
}
