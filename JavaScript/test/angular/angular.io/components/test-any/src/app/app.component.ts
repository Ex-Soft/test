import { Component } from '@angular/core';
import { IDto } from './models/IDto';
import { IComplexObjectDto, IComplexObjectGroupDto, IComplexObjectGroupItemDto } from './models/IComplexObjectDto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'test-any';

  parentValue: string;

  dto: IDto[] = [
    { id: 1, name: 'Name #1', price: 1, count: 1 },
    { id: 2, name: 'Name #2', price: 10, count: 10 },
    { id: 3, name: 'Name #3', price: 100, count: 100 }
  ] as IDto[];

  complexObjectDto: IComplexObjectDto = {
    id: 1,
    name: 'Complex Object #1',
    groups: [
      {
        id: 11,
        name: 'Complex Object #1 Group #1',
        items: [
          { id: 111, name: 'Complex Object #1 Group #1 Item #1'} as IComplexObjectGroupItemDto,
          { id: 112, name: 'Complex Object #1 Group #1 Item #2'} as IComplexObjectGroupItemDto,
          { id: 113, name: 'Complex Object #1 Group #1 Item #3'} as IComplexObjectGroupItemDto,
        ] as IComplexObjectGroupItemDto[]
      } as IComplexObjectGroupDto,
      {
        id: 12,
        name: 'Complex Object #1 Group #2',
        items: [
          { id: 121, name: 'Complex Object #1 Group #2 Item #1'} as IComplexObjectGroupItemDto,
          { id: 122, name: 'Complex Object #1 Group #2 Item #2'} as IComplexObjectGroupItemDto,
          { id: 123, name: 'Complex Object #1 Group #2 Item #3'} as IComplexObjectGroupItemDto,
        ] as IComplexObjectGroupItemDto[]
      } as IComplexObjectGroupDto,
    ] as IComplexObjectGroupDto[]
  } as IComplexObjectDto;

  allChecked: boolean = true;

  allCheckedChange(newValue: boolean): void {
    this.allChecked = newValue;
  }
}
