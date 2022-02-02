import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-view-encapsulation-emulated-parent',
  template: `
    <h2>ViewEncapsulation.Emulated (parent)</h2>
    <div class="view-encapsulation-emulated">ViewEncapsulation.Emulated</div>
    <app-view-encapsulation-none-parent></app-view-encapsulation-none-parent>
  `,
  styles: ['h2, .view-encapsulation-emulated { color: green; }'],
  encapsulation: ViewEncapsulation.Emulated
})
export class ViewEncapsulationEmulatedParentComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
  }
}
