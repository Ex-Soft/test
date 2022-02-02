import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-view-encapsulation-emulated-child',
  template: `
    <h2>ViewEncapsulation.Emulated (child)</h2>
    <div class="view-encapsulation-emulated">ViewEncapsulation.Emulated</div>
  `,
  styles: ['h2, .view-encapsulation-emulated { color: green; }'],
  encapsulation: ViewEncapsulation.Emulated
})
export class ViewEncapsulationEmulatedChildComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
  }
}
