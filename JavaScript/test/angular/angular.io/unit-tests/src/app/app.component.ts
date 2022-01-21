import { Component } from '@angular/core';
import { IData } from './components/components.type';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'unit-tests';

  data: IData = {
    pNumber: 13
  } as IData;
}
