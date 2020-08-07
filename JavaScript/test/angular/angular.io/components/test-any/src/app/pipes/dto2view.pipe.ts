import { Pipe, PipeTransform } from '@angular/core';
import { IView } from '../models/IView';

@Pipe({
  name: 'dto2view'
})
export class Dto2ViewPipe implements PipeTransform {
  transform(val: Array<Partial<IView>>): IView[] {
    return val.map(item => this.dto2view(item));
  }

  dto2view(val: Partial<IView>): IView {
    const view = { ...val } as IView;
    view.total = view.price * view.count;
    view.checked = true;
    return view;
  }
}
