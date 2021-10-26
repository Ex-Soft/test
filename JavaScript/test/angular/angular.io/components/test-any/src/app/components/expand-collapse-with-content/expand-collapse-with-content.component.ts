import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-expand-collapse-with-content',
  templateUrl: './expand-collapse-with-content.component.html',
  styleUrls: ['./expand-collapse-with-content.component.css']
})
export class ExpandCollapseWithContentComponent implements OnInit {
  @Input() legend: string;
  @Input() data: any;

  expandSign = '+';
  collapseSign = '-';

  public isExpanded = false;
  public expandCollapseSign = this.expandSign;

  constructor() {
    console.log('ExpandCollapseWithContentComponent.ctor() data=%o', this.data);
  }

  ngOnInit(): void {
    console.log('ExpandCollapseWithContentComponent.ngOnInit() data=%o', this.data);
  }

  public expandCollapse(): void {
    this.isExpanded = !this.isExpanded;
    this.expandCollapseSign = this.isExpanded ? this.collapseSign : this.expandSign;
  }
}
