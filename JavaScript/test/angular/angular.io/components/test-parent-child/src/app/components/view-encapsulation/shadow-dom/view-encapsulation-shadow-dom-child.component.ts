import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-view-encapsulation-shadow-dom-child',
  template: `
    <h2>ViewEncapsulation.ShadowDom (child)</h2>
    <div class="view-encapsulation-shadow-dom">ViewEncapsulation.ShadowDom</div>
  `,
  styles: ['h2, .view-encapsulation-shadow-dom { color: blue; }'],
  encapsulation: ViewEncapsulation.ShadowDom
})
export class ViewEncapsulationShadowDomChildComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
  }
}
