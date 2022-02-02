// https://www.digitalocean.com/community/tutorials/angular-viewchild-access-component
// https://indepth.dev/exploring-angular-dom-manipulation-techniques-using-viewcontainerref/
// https://medium.com/geekculture/angular-this-is-how-i-finally-understood-host-and-ng-deep-selectors-c829098cf194

import { Component, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import { ParentComponent } from './components/parent/parent.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
  @ViewChild(ParentComponent) parent!: ParentComponent;

  ngAfterViewInit(): void {
    console.log('AppComponent: parent = %o', this.parent);
  }
}
