import { Component, OnInit, OnDestroy } from '@angular/core';
import { untilDestroyed } from 'ngx-take-until-destroy';
import { tap } from 'rxjs/operators';

import { ComplexObjectDtoToViewPipe } from '../../pipes/complex-object-dto-to-view.pipe';
import { ComplexObjectQuery, ComplexObjectService } from '../../core/state/complex-object';
import { IComplexObjectView } from '../../models/IComplexObjectView';

@Component({
  selector: 'app-complex-object',
  templateUrl: './complex-object.component.html',
  styleUrls: ['./complex-object.component.css']
})
export class ComplexObjectComponent implements OnInit, OnDestroy {
  complexObject: IComplexObjectView = null;

  constructor(private query: ComplexObjectQuery, private service: ComplexObjectService) { }

  ngOnInit(): void {
    this.query.state$.subscribe(state => {
      console.log(state);
    });

    this.service.getComplexObjects();

    this.query
      .selectActive()
      .pipe(
        untilDestroyed(this),
        tap(complexObject => {
          if (complexObject) {
            const pipe = new ComplexObjectDtoToViewPipe();
            this.complexObject = pipe.transform(complexObject as Partial<IComplexObjectView>);
          }
        })
      )
      .subscribe();
  }

  ngOnDestroy(): void {}

  onClickCheck(): void {
    this.query.isLoading$.subscribe(result => {
      console.log(result);
    });
  }
}
