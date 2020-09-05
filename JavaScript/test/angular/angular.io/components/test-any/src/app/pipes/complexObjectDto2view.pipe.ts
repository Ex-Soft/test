import { Pipe, PipeTransform } from '@angular/core';
import { IComplexObjectView, IComplexObjectGroupView, IComplexObjectGroupItemView } from '../models/IComplexObjectView';

@Pipe({
  name: 'complexObjectDto2view'
})
export class ComplexObjectDto2ViewPipe implements PipeTransform {
  transform(val: Partial<IComplexObjectView>): IComplexObjectView {
    return this.complexObjectDto2view(val);
  }

  complexObjectDto2view(val: Partial<IComplexObjectView>): IComplexObjectView {
    const view = { ...val } as IComplexObjectView;
    if (view.groups) {
      view.groups = view.groups.map(item => this.complexObjectGroupDto2view(item));
    }
    return view;
  }

  complexObjectGroupDto2view(val: Partial<IComplexObjectGroupView>): IComplexObjectGroupView {
    const view = { ...val } as IComplexObjectGroupView;
    if (view.items) {
      view.items = view.items.map(item => this.complexObjectGroupItemDto2view(item));
    }
    return view;
  }

  complexObjectGroupItemDto2view(val: Partial<IComplexObjectGroupItemView>): IComplexObjectGroupItemView {
    const view = { ...val } as IComplexObjectGroupItemView;
    view.checked = true;
    return view;
  }
}
