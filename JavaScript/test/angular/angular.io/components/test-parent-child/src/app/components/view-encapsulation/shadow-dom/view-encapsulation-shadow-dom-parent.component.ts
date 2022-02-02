import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-view-encapsulation-shadow-dom-parent',
  template: `
    <h2>ViewEncapsulation.ShadowDom (parent)</h2>
    <div class="view-encapsulation-shadow-dom">ViewEncapsulation.ShadowDom</div>
    <app-view-encapsulation-emulated-parent></app-view-encapsulation-emulated-parent>
    <app-view-encapsulation-none-parent></app-view-encapsulation-none-parent>
  `,
  styles: ['h2, .view-encapsulation-shadow-dom { color: blue; }'],
  encapsulation: ViewEncapsulation.ShadowDom
})
export class ViewEncapsulationShadowDomParentComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
  }
}
