import { Component, OnInit, OnDestroy } from '@angular/core';
import { tap } from 'rxjs/operators';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';

import { ComplexObjectDtoToViewPipe } from '../../pipes/complex-object-dto-to-view.pipe';
import { ComplexObjectQuery, ComplexObjectService } from '../../core/state/complex-object';
import { IComplexObjectView } from '../../models/IComplexObjectView';

@UntilDestroy()
@Component({
  selector: 'app-complex-object',
  templateUrl: './complex-object.component.html',
  styleUrls: ['./complex-object.component.css']
})
export class ComplexObjectComponent implements OnInit, OnDestroy {
  complexObject: IComplexObjectView = null;

  constructor(private query: ComplexObjectQuery, private service: ComplexObjectService) { }

  ngOnInit(): void {
    this.query
      .selectAll()
      .pipe(
        untilDestroyed(this),
        tap(complexObjects => {
          if (Array.isArray(complexObjects) && complexObjects.length) {
            const pipe = new ComplexObjectDtoToViewPipe();
            this.complexObject = pipe.transform(complexObjects[0] as Partial<IComplexObjectView>);
          } else {
            this.service.getComplexObjects();
          }
        })
      )
      .subscribe();
  }

  ngOnDestroy(): void {}

  onClickCheck(): void {
    console.log(this.query);
  }
}
