import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { IPeopleView } from 'src/app/models/IPeopleView';

@Component({
  selector: 'app-template-component-one',
  templateUrl: './template-component-one.component.html',
  styleUrls: ['./template-component-one.component.css']
})
export class TemplateComponentOneComponent implements OnInit {
  @Input() wrapper: TemplateRef<any>;
  @Input() data: IPeopleView;

  constructor() {
    console.log('TemplateComponentOneComponent.ctor() data=%o', this.data);
  }

  ngOnInit(): void {
    console.log('TemplateComponentOneComponent.ngOnInit() data=%o', this.data);
  }
}
