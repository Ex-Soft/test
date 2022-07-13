import { Injectable } from '@angular/core';
import { tap, finalize } from 'rxjs/operators';
import { createComplexObject, createComplexObjects } from './complex-object.type';
import { ComplexObjectsStore } from './complex-object.store';
import { ComplexObjectDataService } from './complex-object-data.service';

@Injectable({ providedIn: 'root' })
export class ComplexObjectService {
  constructor(private store: ComplexObjectsStore, private dataService: ComplexObjectDataService) {}

  getComplexObject(id: number): void {
    this.dataService
      .getComplexObject(id)
      .pipe(
        tap(complexObject => {
          this.store.add(createComplexObject(complexObject));
      })).subscribe(
        () => {},
        err => {
          this.store.setError(err.status);
        }
      );
  }

  getComplexObjects(): void {
    this.dataService
      .getComplexObjects()
      .pipe(
        tap(complexObjects => {
          this.store.add(createComplexObjects(complexObjects));
        })
      )
      .subscribe();
  }
}
