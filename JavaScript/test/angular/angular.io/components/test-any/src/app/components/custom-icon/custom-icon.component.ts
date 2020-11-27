import { Component, OnInit, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-custom-icon',
  template: '☻',
  styleUrls: ['./custom-icon.component.css']
})
export class CustomIconComponent implements OnInit, OnDestroy {
  ngOnInit(): void {
    if (window.console && console.log) {
      console.log('app-custom-icon init');
    }
  }

  ngOnDestroy(): void {
    if (window.console && console.log) {
      console.log('app-custom-icon destroy');
    }
  }
}
