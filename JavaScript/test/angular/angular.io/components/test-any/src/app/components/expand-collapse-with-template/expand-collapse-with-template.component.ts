// https://torsten-muller.dev/angular/ng-template-content-injection/

import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-expand-collapse-with-template',
  templateUrl: './expand-collapse-with-template.component.html',
  styleUrls: ['./expand-collapse-with-template.component.css']
})
export class ExpandCollapseWithTemplateComponent implements OnInit {
  @Input() legend: string;
  @Input() data: any;

  expandSign = '+';
  collapseSign = '-';

  public isExpanded = false;
  public expandCollapseSign = this.expandSign;

  constructor() {
    console.log('ExpandCollapseWithTemplateComponent.ctor() data=%o', this.data);
  }

  ngOnInit(): void {
    console.log('ExpandCollapseWithTemplateComponent.ngOnInit() data=%o', this.data);
  }

  public expandCollapse(): void {
    this.isExpanded = !this.isExpanded;
    this.expandCollapseSign = this.isExpanded ? this.collapseSign : this.expandSign;
  }
}
