// https://medium.com/@zacky_14189/embedding-react-components-in-angular-the-easy-way-60f796b68aef

import { Component, OnInit, OnChanges, OnDestroy, AfterViewInit, Input, ViewEncapsulation, ViewChild, ElementRef } from '@angular/core';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { ReactComponent } from '../react/ReactComponent';

const containerElementName = 'ReactComponentWrapper';

@Component({
  selector: 'app-react-component-wrapper',
  template: `<div #${containerElementName} class='ReactComponentWrapper'></div>`,
  styleUrls: ['./react-component-wrapper.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ReactComponentWrapperComponent implements OnInit, OnChanges, OnDestroy, AfterViewInit {
  @ViewChild(containerElementName, {static: false}) containerRef: ElementRef;

  @Input() prop1: string;
  @Input() prop2: string;
  @Input() prop3: number;

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges() {
    this.render();
  }

  ngAfterViewInit() {
    this.render();
  }

  ngOnDestroy() {
    if (this.containerRef) {
      ReactDOM.unmountComponentAtNode(this.containerRef.nativeElement);
    }
  }

  private render() {
    if (this.containerRef) {
      const prop1value = `${this.prop1}`;
      const prop2value = `${this.prop2}`;
      const prop3value = this.prop3;
      ReactDOM.render(<ReactComponent prop1={prop1value} prop2={prop2value} prop3={prop3value} />, this.containerRef.nativeElement);
    }
  }
}
