// https://www.digitalocean.com/community/tutorials/angular-viewchild-access-component
// https://indepth.dev/exploring-angular-dom-manipulation-techniques-using-viewcontainerref/

import { Component, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import { ParentComponent } from './components/parent/parent.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
  title = 'Test Parent-Child';

  @ViewChild(ParentComponent) parent: ParentComponent;

  ngAfterViewInit(): void {
    console.log('AppComponent: parent = %o', this.parent);
  }
}
