import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-view-encapsulation-none-child',
  template: `
    <h2>ViewEncapsulation.None (child)</h2>
    <div class="view-encapsulation-none">ViewEncapsulation.None</div>
  `,
  styles: ['h2, .view-encapsulation-none { color: red; }'],
  encapsulation: ViewEncapsulation.None
})
export class ViewEncapsulationNoneChildComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
  }
}
