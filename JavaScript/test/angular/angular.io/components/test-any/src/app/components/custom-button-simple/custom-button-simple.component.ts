import { Component } from '@angular/core';

@Component({
  selector: 'app-custom-button-simple',
  template: `<button>
               <ng-content></ng-content>
               <ng-content select="app-custom-icon"></ng-content>
            </button>`,
  styleUrls: ['./custom-button-simple.component.css']
})
export class CustomButtonSimpleComponent {
}
