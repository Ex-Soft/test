import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IItemWithEnumDto } from './item-with-enum.type';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class ItemWithEnumDataService {
  baseUrl = 'http://localhost:53683/api/itemwithenum';

  constructor(private http: HttpClient) {}

  getItemsWithEnum(): Observable<Array<Partial<IItemWithEnumDto>>> {
    return this.http.get<Array<IItemWithEnumDto>>(`${this.baseUrl}`).pipe(map(res => res));
  }
}
