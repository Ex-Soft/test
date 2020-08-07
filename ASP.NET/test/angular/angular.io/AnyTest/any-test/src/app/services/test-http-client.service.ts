import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TestHttpClientService<T> {
  constructor(private http: HttpClient) { }

  getData(url: string): Observable<T> {
    console.log('TestHttpClientService<T>.getData(\"%s\")', url);
    return this.http.get<T>(url);
  }
}
