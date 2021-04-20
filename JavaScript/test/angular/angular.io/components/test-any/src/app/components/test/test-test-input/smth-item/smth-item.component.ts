import { Component, Input } from '@angular/core';
import { SmthType } from '../smth.type';

@Component({
  selector: 'app-smth-item',
  templateUrl: './smth-item.component.html',
  styleUrls: ['./smth-item.component.css']
})
export class SmthItemComponent {
  @Input() smthItem: SmthType;
}
