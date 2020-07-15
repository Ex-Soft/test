import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderApiResponse } from '../types/order-api-response.type';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  getData(url: string): Observable<OrderApiResponse> {
    return this.http.get<OrderApiResponse>(url);
  }
}
