import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-view-encapsulation-none-parent',
  template: `
    <h2>ViewEncapsulation.None (parent)</h2>
    <div class="view-encapsulation-none">ViewEncapsulation.None</div>
  `,
  styles: ['h2, .view-encapsulation-none { color: red; }'],
  encapsulation: ViewEncapsulation.None
})
export class ViewEncapsulationNoneParentComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
  }
}
