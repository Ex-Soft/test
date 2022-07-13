import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IComplexObjectDto } from './complex-object.type';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class ComplexObjectDataService {
  baseUrl = 'http://localhost:53683/api/complexobject';

  constructor(private http: HttpClient) {}

  getComplexObject(id: number): Observable<Partial<IComplexObjectDto>> {
    return this.http.get<IComplexObjectDto>(`${this.baseUrl}/${id}`).pipe(map(res => res));
  }

  getComplexObjects(): Observable<Array<Partial<IComplexObjectDto>>> {
    return this.http.get<Array<IComplexObjectDto>>(`${this.baseUrl}`).pipe(map(res => res));
  }
}
