import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-custom-button',
  template: `<button (click)="toggleIcon()">
               <ng-content></ng-content>
               <div *ngIf="showIcon">
                 <ng-content select="app-custom-icon"></ng-content>
               </div>
            </button>`,
  styleUrls: ['./custom-button.component.css']
})
export class CustomButtonComponent {
  showIcon = true;

  toggleIcon(): void {
    this.showIcon = !this.showIcon;
  }
}
