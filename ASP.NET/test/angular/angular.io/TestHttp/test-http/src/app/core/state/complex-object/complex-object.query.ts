import { Injectable } from '@angular/core';
import { QueryEntity } from '@datorama/akita';
import { IComplexObjectDto } from './complex-object.type';
import { ComplexObjectsState, ComplexObjectsStore } from './complex-object.store';

@Injectable({ providedIn: 'root' })
export class ComplexObjectQuery extends QueryEntity<ComplexObjectsState, IComplexObjectDto> {
  constructor(protected store: ComplexObjectsStore) {
    super(store);
  }
}
