import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IItemDto } from './item.type';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class ItemDataService {
  baseUrl = 'http://localhost:53683/api/item';

  constructor(private http: HttpClient) {}

  getItems(): Observable<Array<Partial<IItemDto>>> {
    return this.http.get<Array<IItemDto>>(`${this.baseUrl}`).pipe(map(res => res));
  }
}
