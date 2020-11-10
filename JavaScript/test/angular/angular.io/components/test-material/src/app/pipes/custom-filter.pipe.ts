import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'customFilter'
})
export class CustomFilterPipe implements PipeTransform {
  transform(items: any[], predicate: (item: any) => boolean): any[] {
    if (!items || !predicate) {
      return items;
    }

    return items.filter(predicate);
  }
}
