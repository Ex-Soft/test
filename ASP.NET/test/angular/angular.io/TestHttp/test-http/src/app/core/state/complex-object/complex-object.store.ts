import { Injectable } from '@angular/core';
import { ActiveState, EntityState, EntityStore, StoreConfig } from '@datorama/akita';
import { IComplexObjectDto } from './complex-object.type';

export interface ComplexObjectsState extends EntityState<IComplexObjectDto, number>, ActiveState<IComplexObjectDto> {
}

const initialState: ComplexObjectsState = {
  active: null
};

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'complexObjects', idKey: 'id', resettable: true })
export class ComplexObjectsStore extends EntityStore<ComplexObjectsState, IComplexObjectDto> {
  constructor() {
    super(initialState);

    if (window.console && console.log) {
      console.log('ComplexObjectStore.ctor() %o', this.getValue());
    }
  }
}
