import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ITodoDto } from './todo.type';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class TodoDataService {
  baseUrl = 'http://localhost:53683/api/todo';

  constructor(private http: HttpClient) {}

  getTodo(id: number): Observable<Partial<ITodoDto>> {
    return this.http.get<ITodoDto>(`${this.baseUrl}/${id}`).pipe(map(res => res));
  }

  getTodos(): Observable<Array<Partial<ITodoDto>>> {
    return this.http.get<Array<ITodoDto>>(`${this.baseUrl}`).pipe(map(res => res));
  }
}
