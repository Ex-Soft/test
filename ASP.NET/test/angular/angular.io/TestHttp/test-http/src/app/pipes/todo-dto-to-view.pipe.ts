import { Pipe, PipeTransform } from '@angular/core';
import { ITodoView, ITodoGroupView, ITodoGroupItemView } from '../models/ITodoView';

@Pipe({
  name: 'todoDtoToView'
})
export class TodoDtoToViewPipe implements PipeTransform {
  transform(value: Partial<ITodoView>): ITodoView {
    const view = { ...value } as ITodoView;
    if (view.groups) {
      view.groups = view.groups.map(item => this.TodoGroupDtoToView(item));
    }
    return view;
  }

  TodoGroupDtoToView(val: Partial<ITodoGroupView>): ITodoGroupView {
    const view = { ...val } as ITodoGroupView;
    if (view.items) {
      view.items = view.items.map(item => this.TodoGroupItemDtoToView(item));
    }
    return view;
  }

  TodoGroupItemDtoToView(val: Partial<ITodoGroupItemView>): ITodoGroupItemView {
    const view = { ...val } as ITodoGroupItemView;
    view.checked = true;
    return view;
  }
}
