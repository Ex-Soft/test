import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IData } from './IData';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  constructor(private http: HttpClient) { }

  // https://angular.io/guide/http
  getData(url: string): Observable<IData[]> {
    return this.http.get<IData[]>(url);
  }
}
