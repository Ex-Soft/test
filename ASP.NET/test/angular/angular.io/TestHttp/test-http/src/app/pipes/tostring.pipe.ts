import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'tostring'
})
export class TostringPipe implements PipeTransform {
  transform(value: unknown): string {
      return JSON.stringify(value);
  }
}
