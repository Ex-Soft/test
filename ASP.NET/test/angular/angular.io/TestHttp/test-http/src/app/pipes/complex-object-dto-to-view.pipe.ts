import { Pipe, PipeTransform } from '@angular/core';
import { IComplexObjectView, IComplexObjectGroupView, IComplexObjectGroupItemView } from '../models/IComplexObjectView';

@Pipe({
  name: 'complexObjectDtoToView'
})
export class ComplexObjectDtoToViewPipe implements PipeTransform {
  transform(value: Partial<IComplexObjectView>): IComplexObjectView {
    const view = { ...value } as IComplexObjectView;
    if (view.groups) {
      view.groups = view.groups.map(item => this.complexObjectGroupDtoToView(item));
    }
    return view;
  }

  complexObjectGroupDtoToView(val: Partial<IComplexObjectGroupView>): IComplexObjectGroupView {
    const view = { ...val } as IComplexObjectGroupView;
    if (view.items) {
      view.items = view.items.map(item => this.complexObjectGroupItemDtoToView(item));
    }
    return view;
  }

  complexObjectGroupItemDtoToView(val: Partial<IComplexObjectGroupItemView>): IComplexObjectGroupItemView {
    const view = { ...val } as IComplexObjectGroupItemView;
    view.checked = true;
    return view;
  }
}
