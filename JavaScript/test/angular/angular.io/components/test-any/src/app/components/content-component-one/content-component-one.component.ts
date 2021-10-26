import { Component, Input } from '@angular/core';
import { IPeopleView } from 'src/app/models';

@Component({
  selector: 'app-content-component-one',
  templateUrl: './content-component-one.component.html',
  styleUrls: ['./content-component-one.component.css']
})
export class ContentComponentOneComponent {
  @Input() data: IPeopleView;
}
