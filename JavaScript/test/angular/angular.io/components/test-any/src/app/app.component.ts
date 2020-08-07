import { Component } from '@angular/core';
import { IDto } from './models/IDto';

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

  allChecked: boolean = true;

  allCheckedChange(newValue: boolean): void {
    this.allChecked = newValue;
  }
}
